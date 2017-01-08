using System;
using System.Drawing;
using System.Diagnostics;
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
            
            if (args.Length == 2)
            {
                try
                {
                    Bitmap mazeBMP = new Bitmap(args[0]);
                    Maze testMaze = new Maze(mazeBMP);
                    Bitmap solvedMaze = testMaze.solve();
                    solvedMaze.Save(args[1]);
                }
                catch (ArgumentException e)
                {
                    Debug.WriteLine("Exception caught: {0}", e);
                    Console.WriteLine("Maze not found");
                }
                catch (System.Runtime.InteropServices.ExternalException e)
                {
                    Debug.WriteLine("Exception caught: {0}", e);
                    Console.WriteLine("Cannot write to specified location");
                }
            }
            else
            {
                Console.WriteLine("Wrong number of arguments.");
                Console.WriteLine("Format: maze.exe \"source.[bmp,png,jpg]\" \"destination.[bmp,png,jpg]\"");
            }
            
        }
    }
}
