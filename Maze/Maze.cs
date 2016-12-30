using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * TODO: Find a better way to iterate through an image besides getPixel 
 * 
 */
namespace Maze
{
    /// <summary>
    /// 
    /// </summary>
    public struct Tile
    {
        public bool isEmpty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class TileNode
    {
        public int x;
        public int y;
        public TileNode prev;

        public TileNode(int x, int y, TileNode p)
        {
            this.x = x;
            this.y = y;
            this.prev = p;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Maze
    {
        // test maze image location
        public const String MAZE_PICTURE_1 = "C:\\Users\\Connor\\Desktop\\MazeC#\\maze1.png";
        public const String MAZE_PICTURE_2 = "C:\\Users\\Connor\\Desktop\\MazeC#\\maze2.png";
        public const String MAZE_PICTURE_3 = "C:\\Users\\Connor\\Desktop\\MazeC#\\maze3.png";
        public const String MAZE_PICTURE_1_SOLVED = "C:\\Users\\Connor\\Desktop\\MazeC#\\maze1solved.png";
        public const String MAZE_PICTURE_2_SOLVED = "C:\\Users\\Connor\\Desktop\\MazeC#\\maze2solved.png";
        public const String MAZE_PICTURE_3_SOLVED = "C:\\Users\\Connor\\Desktop\\MazeC#\\maze3solved.png";

        private const int BLACK_WALL_THRESHOLD = 64;
        private const int WHITE_EMPTY_THRESHOLD = 220;
        private const int B_START_THRESHOLD = 210;
        private const int RG_START_THRESHOLD = 50;
        private const int R_FINISH_THRESHOLD = 180;
        private const int GB_FINISH_THRESHOLD = 85;

        private Bitmap originalBitmap;
        private Tile [][] maze;
        public int width { get; private set; }
        public int height { get; private set; }
        public TileNode startTile { get; private set; }
        public TileNode finishTile { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mazeBitmap"></param>
        public Maze(Bitmap mazeBitmap)
        {
            this.originalBitmap = mazeBitmap;
            this.width = mazeBitmap.Width;
            this.height = mazeBitmap.Height;
            this.setTilesFromBitmap(mazeBitmap);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mazeBitmap"></param>
        private void setTilesFromBitmap(Bitmap mazeBitmap)
        {
            this.maze = new Tile[this.height][];
            bool lookingForStart = true;
            bool lookingForFinish = true;

            for(int i = 0; i < this.height; ++i)
            {
                maze[i] = new Tile[this.width];

                for(int j = 0; j < this.width; ++j)
                {
                    Color pixel = mazeBitmap.GetPixel(j, i);

                    if(isWall(pixel))
                    {
                        maze[i][j].isEmpty = false;
                    }
                    else
                    {
                        maze[i][j].isEmpty = true;
                        if (lookingForStart && isStart(pixel))
                        {
                            lookingForStart = false;
                            startTile = new TileNode(j, i, null);
                        }
                        else if (lookingForFinish && isFinish(pixel))
                        {
                            lookingForFinish = false;
                            finishTile = new TileNode(j, i, null);
                        }
                    }
                }
            }

            if(lookingForStart || lookingForFinish)
            {
                // TODO: throw error?
            }
        }

        ~Maze()
        {
            // close any files, windows, or network connections
        }

        public Bitmap solve()
        {
            Queue<TileNode> frontier = new Queue<TileNode>();
            frontier.Enqueue(startTile);

            TileNode currentTile;
            while (frontier.Count > 0)
            {
                currentTile = frontier.Dequeue();
                if(currentTile.x == finishTile.x && currentTile.y == finishTile.y)
                {
                    while(currentTile.prev != null)
                    {
                        this.originalBitmap.SetPixel(currentTile.x, currentTile.y, Color.Green);
                        currentTile = currentTile.prev;
                    }

                    return this.originalBitmap;
                }

                if(this.maze[currentTile.y - 1][currentTile.x].isEmpty)
                {
                    frontier.Enqueue(new TileNode(currentTile.x, currentTile.y - 1, currentTile));
                    this.maze[currentTile.y - 1][currentTile.x].isEmpty = false;
                }
                if (this.maze[currentTile.y + 1][currentTile.x].isEmpty)
                {
                    frontier.Enqueue(new TileNode(currentTile.x, currentTile.y + 1, currentTile));
                    this.maze[currentTile.y + 1][currentTile.x].isEmpty = false;
                }
                if (this.maze[currentTile.y][currentTile.x - 1].isEmpty)
                {
                    frontier.Enqueue(new TileNode(currentTile.x - 1, currentTile.y, currentTile));
                    this.maze[currentTile.y][currentTile.x - 1].isEmpty = false;
                }
                if (this.maze[currentTile.y][currentTile.x + 1].isEmpty)
                {
                    frontier.Enqueue(new TileNode(currentTile.x + 1, currentTile.y, currentTile));
                    this.maze[currentTile.y][currentTile.x + 1].isEmpty = false;
                }
            }
            
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
            return (c.R <= RG_START_THRESHOLD
                && c.G <= RG_START_THRESHOLD
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
                && c.G <= GB_FINISH_THRESHOLD
                && c.B <= GB_FINISH_THRESHOLD);
        }
    }
}
