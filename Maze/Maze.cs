using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Maze
    {
        public const String MAZE_PICTURE_1 = "C:\\Users\\Connor\\Desktop\\MazeC#\\maze1.png";
        public const String MAZE_PICTURE_2 = "C:\\Users\\Connor\\Desktop\\MazeC#\\maze2.png";
        public const String MAZE_PICTURE_3 = "C:\\Users\\Connor\\Desktop\\MazeC#\\maze3.png";

        private Bitmap mazeBitmap;
        private Color topLeftPixel;

        public Maze(String mazeImageLocation)
        {
            this.mazeBitmap = new Bitmap(mazeImageLocation);
            this.topLeftPixel = mazeBitmap.GetPixel(0, 0);
        }

        ~Maze()
        {
            // close any files, windows, or network connections
        }

        public Bitmap getMazeBitmap()
        {
            return this.mazeBitmap;
        }

        public Color getTopLeftPixel()
        {
            return this.topLeftPixel;
        }
    }
}
