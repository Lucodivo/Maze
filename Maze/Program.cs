using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Program
    {

        static void Main(string[] args)
        {
            Maze testMaze = new Maze(new System.Drawing.Bitmap(Maze.MAZE_PICTURE_1));

            // To be used when program is complete
            /*
            if (args.Length == 2)
            {
                // run program
            }
            else
            {
                Console.WriteLine("Wrong number of arguments.");
                Console.WriteLine("Format: maze.exe \"source.[bmp,png,jpg]\" \"destination.[bmp,png,jpg]\"");
            }
            */
        }
    }
}
