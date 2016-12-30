using System;
using System.Drawing;
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
            Maze testMaze = new Maze(new Bitmap(Maze.MAZE_PICTURE_3));
            Bitmap solvedMaze = testMaze.solve();
            solvedMaze.Save(Maze.MAZE_PICTURE_3_SOLVED);

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
