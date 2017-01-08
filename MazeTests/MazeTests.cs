using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maze;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Tests
{
    [TestClass()]
    public class MazeTests
    {
        // test maze image location
        public const String MAZE_PICTURE_1 = "..\\..\\..\\TestData\\maze1.png";
        public const String MAZE_PICTURE_2 = "..\\..\\..\\TestData\\maze2.png";
        public const String MAZE_PICTURE_3 = "..\\..\\..\\TestData\\maze3.png";
        public const String MAZE_PICTURE_4 = "..\\..\\..\\TestData\\maze4.jpg";
        public const String MAZE_PICTURE_5 = "..\\..\\..\\TestData\\maze5.bmp";
        public const String MAZE_NO_SOLUTION = "..\\..\\..\\TestData\\no_solution_maze.bmp";
        public const String MAZE_LARGE = "..\\..\\..\\TestData\\large_maze.png";
        public const String MAZE_CAVE = "..\\..\\..\\TestData\\maze_cave.jpg";
        public const String MAZE_DIVIDE_LINE = "..\\..\\..\\TestData\\maze_divide_line.jpg";
        public const String MAZE_TEMPLATE = "..\\..\\..\\TestData\\maze_template.jpg";
        // test maze image solved saving locations
        public const String MAZE_PICTURE_1_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze1_solved.png";
        public const String MAZE_PICTURE_2_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze2_solved.png";
        public const String MAZE_PICTURE_3_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze3_solved.png";
        public const String MAZE_PICTURE_4_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze4_solved.jpg";
        public const String MAZE_PICTURE_5_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze5_solved.bmp";
        public const String MAZE_LARGE_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\large_maze_solved.png";
        public const String MAZE_CAVE_SOLVED = "..\\..\\..\\TestData\\maze_cave_solved.jpg";
        public const String MAZE_DIVIDE_LINE_SOLVED = "..\\..\\..\\TestData\\maze_divide_line_solved.jpg";
        public const String MAZE_TEMPLATE_SOLVED = "..\\..\\..\\TestData\\maze_template_solved.jpg";

        private Maze m;
        private const bool SAVE_TEST_SOLUTIONS = true;

        [TestInitialize()]
        public void Initialize()
        {
            //
        }

        /// <summary>
        /// Tests that the Maze1 initializes successfully
        /// </summary>
        [TestMethod()]
        public void Maze1_Initialization_Test()
        {
            m = new Maze(new Bitmap(MAZE_PICTURE_1));

            Assert.IsNotNull(m);

            // dimensions of maze1.png
            int expectedWidth = 441;
            int expectedHeight = 441;

            Assert.AreEqual(expectedWidth, m.Width);
            Assert.AreEqual(expectedHeight, m.Height);

            // top left pixel location of start and finish squares
            int expectedStartX = 22;
            int expectedStartY = 417;
            int expectedFinishX = 243;
            int expectedFinishY = 418;

            Assert.AreEqual(expectedStartX, m.StartTile.X);
            Assert.AreEqual(expectedStartY, m.StartTile.Y);
            Assert.AreEqual(expectedFinishX, m.FinishTile.X);
            Assert.AreEqual(expectedFinishY, m.FinishTile.Y);
        }

        [TestMethod()]
        public void Solve_Maze_No_Solution_Test()
        {
            Maze testMaze = new Maze(new Bitmap(MAZE_NO_SOLUTION));
            Bitmap solvedMaze = testMaze.solve();
            Assert.IsNull(solvedMaze);
        }

        /// <summary>
        /// Tests that program successfully solves maze1.png
        /// </summary>
        [TestMethod()]
        public void Solve_Maze1_Test()
        {
            Maze testMaze = new Maze(new Bitmap(MAZE_PICTURE_1));
            Bitmap solvedMaze = testMaze.solve();
            Assert.IsNotNull(solvedMaze);

            if(SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_PICTURE_1_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// Tests that program successfully solves maze2.png
        /// </summary>
        [TestMethod()]
        public void Solve_Maze2_Test()
        {
            Maze testMaze = new Maze(new Bitmap(MAZE_PICTURE_2));
            Bitmap solvedMaze = testMaze.solve();
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_PICTURE_2_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// Tests that program successfully solves maze3.png
        /// </summary>
        [TestMethod()]
        public void Solve_Maze3_Test()
        {
            Maze testMaze = new Maze(new Bitmap(MAZE_PICTURE_3));
            Bitmap solvedMaze = testMaze.solve();
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_PICTURE_3_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// Tests that program successfully solves jpg files
        /// </summary>
        [TestMethod()]
        public void Solve_Maze4_JPG_Test()
        {
            Maze testMaze = new Maze(new Bitmap(MAZE_PICTURE_4));
            Bitmap solvedMaze = testMaze.solve();
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_PICTURE_4_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// Tests that the program sucessfully solves bmp files
        /// </summary>
        [TestMethod()]
        public void Solve_Maze5_BMP_Test()
        {
            Maze testMaze = new Maze(new Bitmap(MAZE_PICTURE_5));
            Bitmap solvedMaze = testMaze.solve();
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_PICTURE_5_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// Tests that the program sucessfully solves large files (and gif files)
        /// </summary>
        [TestMethod()]
        public void Solve_Maze_Large_Test()
        {
            Maze testMaze = new Maze(new Bitmap(MAZE_LARGE));
            Bitmap solvedMaze = testMaze.solve();
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_LARGE_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void Solve_Maze_Template_Test()
        {
            Maze testMaze = new Maze(new Bitmap(MAZE_TEMPLATE));
            Bitmap solvedMaze = testMaze.solve();
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_TEMPLATE_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void Solve_Maze_Divide_Line_Test()
        {
            Maze testMaze = new Maze(new Bitmap(MAZE_DIVIDE_LINE));
            Bitmap solvedMaze = testMaze.solve();
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_DIVIDE_LINE_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod()]
        public void Solve_Maze_Cave_Test()
        {
            Maze testMaze = new Maze(new Bitmap(MAZE_CAVE));
            Bitmap solvedMaze = testMaze.solve();
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_CAVE_SOLVED); // save test solution bitmap
            }
        }
    }
}