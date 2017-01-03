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
        public bool isEmpty;
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

        // original bitmap stored for drawing solution
        private Bitmap originalBitmap;
        // maze used to store walls and empty space
        private Tile [][] maze;
        // dimensions of maze
        public int width { get; private set; }
        public int height { get; private set; }
        // 
        public TileNode startTile { get; private set; }
        public TileNode finishTile { get; private set; }

        /// <summary>
        /// Initializing the Maze class with a Bitmap that follows rules specified in class description.
        /// </summary>
        /// <param name="mazeBitmap"></param>
        public Maze(Bitmap mazeBitmap)
        {
            this.originalBitmap = mazeBitmap;
            this.width = mazeBitmap.Width;
            this.height = mazeBitmap.Height;
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
            this.maze = new Tile[this.height][];
            bool lookingForStart = true;
            bool lookingForFinish = true;
            Point topLeftStart = new Point(0, 0);
            Point bottomRightStart = new Point(0, 0);
            Point topLeftFinish = new Point(0, 0);
            Point bottomRightFinish = new Point(0, 0);

            for(int i = 0; i < this.height; ++i)
            {
                maze[i] = new Tile[this.width];

                for(int j = 0; j < this.width; ++j)
                {
                    /**
                     * TODO: Find a better way to iterate through an image besides getPixel???
                     */
                    Color pixel = this.originalBitmap.GetPixel(j, i);

                    if(isWall(pixel))
                    {
                        maze[i][j].isEmpty = false;
                    }
                    else
                    {
                        maze[i][j].isEmpty = true;
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

            // if we never found start or finish, the bitmap is doesn't follow the specified rules
            if(topLeftStart == new Point(0, 0) || topLeftFinish == new Point(0, 0))
            {
                throw (new UnacceptableMazeImageException("Image does not contain a proper maze"));
            }

            startTile = new TileNode();
            startTile.X = (topLeftStart.X + bottomRightStart.X) / 2;
            startTile.Y = (topLeftStart.Y + bottomRightStart.Y) / 2;
            finishTile = new TileNode();
            finishTile.X = (topLeftFinish.X + bottomRightFinish.X) / 2;
            finishTile.Y = (topLeftFinish.Y + bottomRightFinish.Y) / 2;
            
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
        public Bitmap solve()
        {
            // create a frontier and enqueue the starting tile
            Frontier<TileNode> frontier = new ManhattanAStarFrontier(finishTile);
            frontier.Enqueue(startTile);
            
            // while there are still nodes to be visited in the frontier
            while (!frontier.isEmpty())
            {
                // visit node
                TileNode currentTile = frontier.Dequeue();
                // if node is at ending position, we simply need to return the solution
                if(currentTile.X == finishTile.X && currentTile.Y == finishTile.Y)
                {
                    // while the current node isn't the startTile
                    while(currentTile.Prev != null)
                    {
                        // set pixel of original bitmap to green (solution) and get the previous pixel
                        // in the traversal
                        this.originalBitmap.SetPixel(currentTile.X, currentTile.Y, Color.Green);
                        currentTile = currentTile.Prev;
                    }

                    // return the solution as a bitmap
                    return this.originalBitmap;
                }

                // Values of x and y that are used for diagonal and lateral moves
                int lowerX = currentTile.X - 1;
                int upperX = currentTile.X + 1;
                int lowerY = currentTile.Y - 1;
                int upperY = currentTile.Y + 1;
                int nextDepth = currentTile.Cost + 1;

                
                // enqueue diagonal moves
                // need to be handled uniquely due to the potential for clipping
                // through a diagonal wall.
                // MUST be added to frontier before lateral moves, due to setting isEmpty
                if (this.maze[lowerY][lowerX].isEmpty
                    && (this.maze[lowerY][currentTile.X].isEmpty
                    || this.maze[currentTile.Y][lowerX].isEmpty))
                {
                    frontier.Enqueue(new TileNode(lowerX, lowerY, nextDepth, currentTile));
                    this.maze[lowerY][lowerX].isEmpty = false;
                }
                if (this.maze[lowerY][upperX].isEmpty
                    && (this.maze[lowerY][currentTile.X].isEmpty
                    || this.maze[currentTile.Y][upperX].isEmpty))
                {
                    frontier.Enqueue(new TileNode(upperX, lowerY, nextDepth, currentTile));
                    this.maze[lowerY][upperX].isEmpty = false;
                }
                if (this.maze[upperY][upperX].isEmpty
                    && (this.maze[currentTile.Y][upperX].isEmpty
                    || this.maze[upperY][currentTile.X].isEmpty))
                {
                    frontier.Enqueue(new TileNode(upperX, upperY, nextDepth, currentTile));
                    this.maze[upperY][upperX].isEmpty = false;
                }
                if (this.maze[upperY][lowerX].isEmpty
                    && (this.maze[upperY][currentTile.X].isEmpty
                    || this.maze[currentTile.Y][lowerX].isEmpty))
                {
                    frontier.Enqueue(new TileNode(lowerX, upperY, nextDepth, currentTile));
                    this.maze[upperY][lowerX].isEmpty = false;
                }

                // enqueue lateral moves
                if (this.maze[lowerY][currentTile.X].isEmpty)
                {
                    frontier.Enqueue(new TileNode(currentTile.X, lowerY, nextDepth, currentTile));
                    this.maze[lowerY][currentTile.X].isEmpty = false;
                }
                if (this.maze[currentTile.Y][upperX].isEmpty)
                {
                    frontier.Enqueue(new TileNode(upperX, currentTile.Y, nextDepth, currentTile));
                    this.maze[currentTile.Y][upperX].isEmpty = false;
                }
                if (this.maze[upperY][currentTile.X].isEmpty)
                {
                    frontier.Enqueue(new TileNode(currentTile.X, upperY, nextDepth, currentTile));
                    this.maze[upperY][currentTile.X].isEmpty = false;
                }
                if (this.maze[currentTile.Y][lowerX].isEmpty)
                {
                    frontier.Enqueue(new TileNode(lowerX, currentTile.Y, nextDepth, currentTile));
                    this.maze[currentTile.Y][lowerX].isEmpty = false;
                }
            }
            
            // return null if no solution is found
            return null;
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
    }
}
