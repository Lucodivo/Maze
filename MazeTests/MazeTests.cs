using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using Maze;
using Maze.Model.Frontier;
using Maze.Util;

namespace MazeTests
{
    /// <summary>
    /// test class used for testing the MazeSolver class
    /// </summary>
    [TestClass()]
    public class MazeSolverTests
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
        public const String MAZE_NOT_A_MAZE = "..\\..\\..\\TestData\\maze_not_a_maze.jpg";
        // test maze image solved saving locations
        public const String MAZE_PICTURE_1_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze1_solved.png";
        public const String MAZE_PICTURE_2_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze2_solved.png";
        public const String MAZE_PICTURE_3_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze3_solved.png";
        public const String MAZE_PICTURE_4_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze4_solved.jpg";
        public const String MAZE_PICTURE_5_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze5_solved.bmp";
        public const String MAZE_LARGE_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\large_maze_solved.png";
        public const String MAZE_CAVE_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze_cave_solved.jpg";
        public const String MAZE_DIVIDE_LINE_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze_divide_line_solved.jpg";
        public const String MAZE_TEMPLATE_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze_template_solved.jpg";
        public const String MAZE_PICTURE_MULT1_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze_mult1_solved.png";
        public const String MAZE_PICTURE_MULT2_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze_mult2_solved.png";
        public const String MAZE_PICTURE_MULT3_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze_mult3_solved.png";
        public const String MAZE_PICTURE_MULT4_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze_mult4_solved.png";

        public const bool SAVE_TEST_SOLUTIONS = true;

        private MazeSolver m;

        /// <summary>
        /// Tests that the Maze1 initializes successfully
        /// </summary>
        [TestMethod()]
        public void Maze1_Initialization_Test()
        {
            m = new MazeSolver(new Bitmap(MAZE_PICTURE_1));

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

        /// <summary>
        /// Tests that the program can handle a maze without a solution gracefully
        /// </summary>
        [TestMethod()]
        public void Solve_Maze_No_Solution_Test()
        {
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_NO_SOLUTION));
            Bitmap solvedMaze = testMaze.Solve(new ManhattanAStarFrontier());
            Assert.IsNull(solvedMaze);
        }

        /// <summary>
        /// Tests that the program will appropriately throw an exception if the image is not a maze
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(UnacceptableMazeImageException),
            "Image does not contain a start and/or end point")]
        public void Solve_Maze_Not_A_Maze_Test()
        {
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_NOT_A_MAZE));
        }

        /// <summary>
        /// Tests that program successfully solves maze1.png
        /// </summary>
        [TestMethod()]
        public void Solve_Maze1_Test()
        {
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_PICTURE_1));
            Bitmap solvedMaze = testMaze.Solve(new ManhattanAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
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
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_PICTURE_2));
            Bitmap solvedMaze = testMaze.Solve(new ManhattanAStarFrontier());
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
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_PICTURE_3));
            Bitmap solvedMaze = testMaze.Solve(new ManhattanAStarFrontier());
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
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_PICTURE_4));
            Bitmap solvedMaze = testMaze.Solve(new ManhattanAStarFrontier());
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
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_PICTURE_5));
            Bitmap solvedMaze = testMaze.Solve(new ManhattanAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_PICTURE_5_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// Tests that the program sucessfully solves large files (and gif files)
        /// Great for testing efficiency of algorithms
        /// </summary>
        [TestMethod()]
        public void Solve_Maze_Large_Test()
        {
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_LARGE));
            Bitmap solvedMaze = testMaze.Solve(new ManhattanAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_LARGE_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// Tests that a single maze object can solve a maze multiple ways
        /// </summary>
        [TestMethod()]
        public void Solve_Maze_Multiple_Test()
        {
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_PICTURE_5));
            Bitmap solvedMaze1 = testMaze.Solve(new BestFSAStarFrontier());
            Assert.IsNotNull(solvedMaze1);

            Bitmap solvedMaze2 = testMaze.Solve(new DjikstrasAStarFrontier());
            Assert.IsNotNull(solvedMaze2);

            Bitmap solvedMaze3 = testMaze.Solve(new EuclideanAStarFrontier());
            Assert.IsNotNull(solvedMaze3);

            Bitmap solvedMaze4 = testMaze.Solve(new ManhattanAStarFrontier());
            Assert.IsNotNull(solvedMaze4);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze1.Save(MAZE_PICTURE_MULT1_SOLVED); // save test solution bitmap
                solvedMaze2.Save(MAZE_PICTURE_MULT2_SOLVED); // save test solution bitmap
                solvedMaze3.Save(MAZE_PICTURE_MULT3_SOLVED); // save test solution bitmap
                solvedMaze4.Save(MAZE_PICTURE_MULT4_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// Used to test heuristics and how they behave with no obstacles
        /// </summary>
        [TestMethod()]
        public void Solve_Maze_Template_Test()
        {
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_TEMPLATE));
            Bitmap solvedMaze = testMaze.Solve(new ManhattanAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_TEMPLATE_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// Used to test heuristics and how they behave with a single dividing line
        /// </summary>
        [TestMethod()]
        public void Solve_Maze_Divide_Line_Test()
        {
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_DIVIDE_LINE));
            Bitmap solvedMaze = testMaze.Solve(new ManhattanAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_DIVIDE_LINE_SOLVED); // save test solution bitmap
            }
        }

        /// <summary>
        /// Used to test heuristics and how they behave with a cave meant to trap expanding nodes
        /// </summary>
        [TestMethod()]
        public void Solve_Maze_Cave_Test()
        {
            MazeSolver testMaze = new MazeSolver(new Bitmap(MAZE_CAVE));
            Bitmap solvedMaze = testMaze.Solve(new ManhattanAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_CAVE_SOLVED); // save test solution bitmap
            }
        }
    }
}