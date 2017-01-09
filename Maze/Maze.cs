using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// Tiles to hold the logic of the maze
    /// </summary>
    public struct Tile
    {
        // false means the tile is a wall
        public bool isTraversable;
    }

    /// <summary>
    /// The Maze class solves a given maze and returns the solution in green. 
    /// Takes in a Bitmap representation of a maze which abide the following rules:
    /// 1) Maze is solvable
    /// 2) Walls are maked as black
    /// 3) Starting position is marked as red
    /// 4) Finishing position is marked as blue
    /// 5) Maze is completely surrounded by black walls
    /// 6) All other pixels are considered traversable space
    /// </summary>
    public class Maze
    {
        // threshold for RGB values for determining "white" and "black"
        private const int BLACK_WALL_THRESHOLD = 64;
        private const int WHITE_EMPTY_THRESHOLD = 220;

        // threshold for RGB values for determining "blue"
        private const int R_START_THRESHOLD = 65;
        private const int G_START_THRESHOLD = 180;
        private const int B_START_THRESHOLD = 190;
        
        // threshold for RGB values for determining "red"
        private const int R_FINISH_THRESHOLD = 180;
        private const int G_FINISH_THRESHOLD = 40;
        private const int B_FINISH_THRESHOLD = 140;

        // Affects the cost 
        private const int LATERAL_MOVE_COST = 1;
        private const int DIAGONAL_MOVE_COST = 2;

        // width for the solution to be drawn with
        private const int DRAW_WIDTH = 1;

        // original bitmap stored for drawing solution
        private Bitmap originalBitmap;
        // maze used to store walls and empty space
        private Tile [][] tiles;
        // dimensions of maze
        private int width;
        private int height;
        // TileNodes to keep track of start and finishing pixels of the maze
        private TileNode startTile;
        private TileNode finishTile;

        public int Width
        {
            get
            {
                return width;
            }

            private set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            private set
            {
                height = value;
            }
        }

        public TileNode StartTile
        {
            get
            {
                return startTile;
            }

            private set
            {
                startTile = value;
            }
        }

        public TileNode FinishTile
        {
            get
            {
                return finishTile;
            }

            private set
            {
                finishTile = value;
            }
        }

        /// <summary>
        /// Initializing the Maze class with a Bitmap that follows rules specified in class description.
        /// </summary>
        /// <param name="mazeBitmap"></param>
        public Maze(Bitmap mazeBitmap)
        {
            this.originalBitmap = mazeBitmap;
            this.Width = mazeBitmap.Width;
            this.Height = mazeBitmap.Height;
            this.setTilesFromBitmap();
        }

        /// <summary>
        /// Sets all values of the logical maze that will be used to traverse.
        /// Sets the values of the starting and ending locations
        /// 
        /// NOTE: Since we already traverse the bitmap to find starting and ending locations, 
        /// we make use of this loop to store the maze in a structure that is easier to travese
        /// </summary>
        private void setTilesFromBitmap()
        {
            // initialize the amount of rows that will exist in the maze
            this.tiles = new Tile[this.Height][];
            
            // Track if we've found at least one pixel of start or finish
            bool lookingForStart = true;
            bool lookingForFinish = true;

            // Points used to acquire the center of the starting and finishing points
            Point topLeftStart = new Point(0, 0);
            Point bottomRightStart = new Point(0, 0);
            Point topLeftFinish = new Point(0, 0);
            Point bottomRightFinish = new Point(0, 0);

            // for every row in the maze
            for(int i = 0; i < this.Height; ++i)
            {
                // initialize that row
                tiles[i] = new Tile[this.Width];

                // for every cell
                for(int j = 0; j < this.Width; ++j)
                {
                    /**
                     * TODO: Find a better way to iterate through an image besides getPixel???
                     */
                    // acquire the pixel of the corresponding pixel
                    Color pixel = this.originalBitmap.GetPixel(j, i);

                    // check if the pixel represents a wall
                    if(isWall(pixel))
                    {
                        // false represents a wall
                        tiles[i][j].isTraversable = false;
                    }
                    else
                    {
                        // all non-walls are traversable space
                        tiles[i][j].isTraversable = true;

                        if (isStart(pixel))
                        {
                            if(lookingForStart)
                            {
                                lookingForStart = false;
                                topLeftStart.X = j;
                                topLeftStart.Y = i;
                            }
                            bottomRightStart.X = j;
                            bottomRightStart.Y = i;
                        }
                        else if (isFinish(pixel))
                        {
                            if(lookingForFinish)
                            {
                                lookingForFinish = false;
                                topLeftFinish.X = j;
                                topLeftFinish.Y = i;
                            }
                            bottomRightFinish.X = j;
                            bottomRightFinish.Y = i;
                        }
                        // TODO: Error if it is not empty
                    }
                }
            }

            // if we never found start or finish, the bitmap doesn't follow the specified rules
            if(topLeftStart == new Point(0, 0) || topLeftFinish == new Point(0, 0))
            {
                throw (new UnacceptableMazeImageException("Image does not contain a start and/or end point"));
            }

            StartTile = new TileNode();
            StartTile.X = (topLeftStart.X + bottomRightStart.X) / 2;
            StartTile.Y = (topLeftStart.Y + bottomRightStart.Y) / 2;
            FinishTile = new TileNode();
            FinishTile.X = (topLeftFinish.X + bottomRightFinish.X) / 2;
            FinishTile.Y = (topLeftFinish.Y + bottomRightFinish.Y) / 2;
            
        }

        ~Maze()
        {
            // close any files, windows, or network connections
        }

        /// <summary>
        /// Function that solves the given bitmap and returns the solution as a bitmap.
        /// Currently solves maze using BFS.
        /// </summary>
        /// <returns>Maze solution as a bitmap</returns>
        public Bitmap solve(IFrontier<TileNode> frontier)
        {
            if(!frontier.isEmpty())
            {
                return null;
            }

            // Scaling equation taken from this webpage
            // h = (1.0 + p), where p < (minimum cost of single step) / (max path length)
            // http://theory.stanford.edu/~amitp/GameProgramming/Heuristics.html
            int maxPathLength = (this.Width * this.Height) / 2;
            float hScale = 1.0f + (1.0f / 1000);

            Tile[][] traversingTiles = copyTiles();
            
            frontier.Enqueue(StartTile);
            
            // while there are still nodes to be visited in the frontier
            while (!frontier.isEmpty())
            {
                // visit node
                TileNode currentTile = frontier.Dequeue();
                // if node is at ending position, we simply need to return the solution
                if(TileNode.SamePosition(currentTile, FinishTile))
                {
                    // return the solution as a bitmap
                    return drawSolution(currentTile, DRAW_WIDTH);
                }

                // Values of x and y that are used for diagonal and lateral moves
                int lowerX = currentTile.X - 1;
                int upperX = currentTile.X + 1;
                int lowerY = currentTile.Y - 1;
                int upperY = currentTile.Y + 1;
                int diagonalDepth = currentTile.Depth + DIAGONAL_MOVE_COST;
                int lateralDepth = currentTile.Depth + LATERAL_MOVE_COST;
                
                // enqueue diagonal moves
                // need to be handled uniquely due to the potential for clipping
                // through a diagonal wall.
                // MUST be added to frontier before lateral moves, due to setting isEmpty
                if (traversingTiles[lowerY][lowerX].isTraversable
                    && (traversingTiles[lowerY][currentTile.X].isTraversable
                    || traversingTiles[currentTile.Y][lowerX].isTraversable))
                {
                    frontier.Enqueue(new TileNode(lowerX, lowerY, diagonalDepth, currentTile));
                    traversingTiles[lowerY][lowerX].isTraversable = false;
                }
                if (traversingTiles[lowerY][upperX].isTraversable
                    && (traversingTiles[lowerY][currentTile.X].isTraversable
                    || traversingTiles[currentTile.Y][upperX].isTraversable))
                {
                    frontier.Enqueue(new TileNode(upperX, lowerY, diagonalDepth, currentTile));
                    traversingTiles[lowerY][upperX].isTraversable = false;
                }
                if (traversingTiles[upperY][upperX].isTraversable
                    && (traversingTiles[currentTile.Y][upperX].isTraversable
                    || traversingTiles[upperY][currentTile.X].isTraversable))
                {
                    frontier.Enqueue(new TileNode(upperX, upperY, diagonalDepth, currentTile));
                    traversingTiles[upperY][upperX].isTraversable = false;
                }
                if (traversingTiles[upperY][lowerX].isTraversable
                    && (traversingTiles[upperY][currentTile.X].isTraversable
                    || traversingTiles[currentTile.Y][lowerX].isTraversable))
                {
                    frontier.Enqueue(new TileNode(lowerX, upperY, diagonalDepth, currentTile));
                    traversingTiles[upperY][lowerX].isTraversable = false;
                }

                // enqueue lateral moves
                if (traversingTiles[lowerY][currentTile.X].isTraversable)
                {
                    frontier.Enqueue(new TileNode(currentTile.X, lowerY, lateralDepth, currentTile));
                    traversingTiles[lowerY][currentTile.X].isTraversable = false;
                }
                if (traversingTiles[currentTile.Y][upperX].isTraversable)
                {
                    frontier.Enqueue(new TileNode(upperX, currentTile.Y, lateralDepth, currentTile));
                    traversingTiles[currentTile.Y][upperX].isTraversable = false;
                }
                if (traversingTiles[upperY][currentTile.X].isTraversable)
                {
                    frontier.Enqueue(new TileNode(currentTile.X, upperY, lateralDepth, currentTile));
                    traversingTiles[upperY][currentTile.X].isTraversable = false;
                }
                if (traversingTiles[currentTile.Y][lowerX].isTraversable)
                {
                    frontier.Enqueue(new TileNode(lowerX, currentTile.Y, lateralDepth, currentTile));
                    traversingTiles[currentTile.Y][lowerX].isTraversable = false;
                }
            }
            
            // return null if no solution is found
            return null;
        }

        public Bitmap solve()
        {
            return solve(new BFSFrontier<TileNode>());
        }

        private Bitmap drawSolution(TileNode currentTile)
        {
            Bitmap solutionBitmap = new Bitmap(this.originalBitmap);

            while (currentTile.Prev != null)
            {
                // set pixel of original bitmap to green (solution) and get the previous pixel
                // in the traversal
                solutionBitmap.SetPixel(currentTile.X, currentTile.Y, Color.Green);
                currentTile = currentTile.Prev;
            }
            return solutionBitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentTile"></param>
        /// <param name="drawWidth"></param>
        /// <returns></returns>
        private Bitmap drawSolution(TileNode currentTile, int drawWidth)
        {
            // while the current node isn't the startTile
            while (currentTile.Prev != null)
            {
                // set pixel of original bitmap to green (solution) and get the previous pixel
                // in the traversal
                this.originalBitmap.SetPixel(currentTile.X, currentTile.Y, Color.Green);
                int iWidth = drawWidth - 1;
                TileNode prevTile = currentTile.Prev;
                bool expandVertically = (currentTile.Y == prevTile.Y);
                if(expandVertically)
                {
                    bool canExpandUp = true;
                    bool canExpandDown = true;
                    int delta = 1;
                    while (iWidth > 0 && (canExpandDown || canExpandUp))
                    {
                        if (canExpandUp && this.tiles[currentTile.Y + delta][currentTile.X].isTraversable)
                        {
                            this.originalBitmap.SetPixel(currentTile.X, currentTile.Y + delta, Color.Green);
                            --iWidth;
                        }
                        else
                        {
                            canExpandUp = false;
                        }
                        if (canExpandDown && this.tiles[currentTile.Y - delta][currentTile.X].isTraversable)
                        {
                            this.originalBitmap.SetPixel(currentTile.X, currentTile.Y - delta, Color.Green);
                            --iWidth;
                        }
                        else
                        {
                            canExpandDown = false;
                        }
                        ++delta;
                    }
                }
                else
                {
                    bool canExpandRight = true;
                    bool canExpandLeft = true;
                    int delta = 1;
                    while (iWidth > 0 && (canExpandLeft || canExpandRight))
                    {
                        if (canExpandRight && this.tiles[currentTile.Y][currentTile.X + delta].isTraversable)
                        {
                            this.originalBitmap.SetPixel(currentTile.X + delta, currentTile.Y, Color.Green);
                            --iWidth;
                        }
                        else
                        {
                            canExpandRight = false;
                        }
                        if (canExpandLeft && this.tiles[currentTile.Y][currentTile.X - delta].isTraversable)
                        {
                            this.originalBitmap.SetPixel(currentTile.X - delta, currentTile.Y, Color.Green);
                            --iWidth;
                        }
                        else
                        {
                            canExpandLeft = false;
                        }
                        ++delta;
                    }
                }

                currentTile = prevTile;
            }

            // return the solution as a bitmap
            return this.originalBitmap;
        }

        /// <summary>
        /// Checks if a Color (pixel) is a wall in the maze
        /// </summary>
        /// <param name="c">Color (pixel) to check</param>
        /// <returns>true if it is a wall</returns>
        private bool isWall(Color c)
        {
            return (c.R <= BLACK_WALL_THRESHOLD 
                && c.G <= BLACK_WALL_THRESHOLD 
                && c.B <= BLACK_WALL_THRESHOLD);
        }

        /// <summary>
        /// Checks if a Color (pixel) is empty in the maze
        /// </summary>
        /// <param name="c">Color (pixel) to check</param>
        /// <returns>true if it is empty</returns>
        private bool isEmpty(Color c)
        {
            return (c.R >= WHITE_EMPTY_THRESHOLD
                && c.G >= WHITE_EMPTY_THRESHOLD
                && c.B >= WHITE_EMPTY_THRESHOLD);
        }

        /// <summary>
        /// Checks if a Color (pixel) is a starting position in the maze
        /// </summary>
        /// <param name="c">Color (pixel) to check</param>
        /// <returns>true if it is starting position</returns>
        private bool isStart(Color c)
        {
            return (c.R <= R_START_THRESHOLD
                && c.G <= G_START_THRESHOLD
                && c.B >= B_START_THRESHOLD);
        }

        /// <summary>
        /// Checks if a Color (pixel) is a finishing position in the maze
        /// </summary>
        /// <param name="c">Color (pixel) to check</param>
        /// <returns>true if it is finishing position</returns>
        private bool isFinish(Color c)
        {
            return (c.R >= R_FINISH_THRESHOLD
                && c.G <= G_FINISH_THRESHOLD
                && c.B <= B_FINISH_THRESHOLD);
        }

        private Tile[][] copyTiles()
        {
            Tile[][] tilesCopy = new Tile[this.Height][];
            for(int i = 0; i < this.Height; ++i)
            {
                tilesCopy[i] = new Tile[this.Width];
                Array.Copy(this.tiles[i], tilesCopy[i], this.Width);
            }

            return tilesCopy;
        }
    }
}
