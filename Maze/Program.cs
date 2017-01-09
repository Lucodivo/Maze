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
                    MazeSolver testMaze = new MazeSolver(mazeBMP);
                    Bitmap solvedMaze = testMaze.Solve();
                    if(solvedMaze != null)
                    {
                        solvedMaze.Save(args[1]);
                        Console.WriteLine("Solution saved to: {0}", args[1]);
                    }
                    else
                    {
                        Console.WriteLine("Maze has no solution");
                    }
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
                catch (UnacceptableMazeImageException e)
                {
                    Debug.WriteLine("Exception caught: {0}", e);
                    Console.WriteLine(e.Message);
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
