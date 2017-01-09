using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maze;
using Maze.Util;
using Maze.Model.Frontier;

namespace MazeTests
{
    /// <summary>
    /// Test class used for testing the different Frontier classes
    /// </summary>
    [TestClass()]
    public class FrontierTests
    {
        public const String MAZE_BESTFS_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\Frontiers\\maze_bestfs_solved.png";
        public const String MAZE_BFS_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\Frontiers\\maze_bfs_solved.png";
        public const String MAZE_CHEBYSHEV_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\Frontiers\\maze_chebyshev_solved.png";
        public const String MAZE_DFS_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\Frontiers\\maze_dfs_solved.png";
        public const String MAZE_DJIKSTRAS_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\Frontiers\\maze_djikstras_solved.png";
        public const String MAZE_EUCLIDIAN_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\Frontiers\\maze_euclidian_solved.png";
        public const String MAZE_MANHATTAN_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\Frontiers\\maze_manhattan_solved.png";

        [TestMethod()]
        public void BestFSAStarFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solvedMaze = m.Solve(new BestFSAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (MazeSolverTests.SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_BESTFS_SOLVED); // save test solution bitmap
            }
        }

        [TestMethod()]
        public void BFSFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solvedMaze = m.Solve(new BFSFrontier<TileNode>());
            Assert.IsNotNull(solvedMaze);

            if (MazeSolverTests.SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_BFS_SOLVED); // save test solution bitmap
            }
        }

        [TestMethod()]
        public void ChebyshevAStarFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solvedMaze = m.Solve(new ChebyshevAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (MazeSolverTests.SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_CHEBYSHEV_SOLVED); // save test solution bitmap
            }
        }

        [TestMethod()]
        public void DFSFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solvedMaze = m.Solve(new DFSFrontier<TileNode>());
            Assert.IsNotNull(solvedMaze);

            if (MazeSolverTests.SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_DFS_SOLVED); // save test solution bitmap
            }
        }

        [TestMethod()]
        public void DjikstrasAStarFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solvedMaze = m.Solve(new DjikstrasAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (MazeSolverTests.SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_DJIKSTRAS_SOLVED); // save test solution bitmap
            }
        }

        [TestMethod()]
        public void EuclidianAStarFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solvedMaze = m.Solve(new EuclideanAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (MazeSolverTests.SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_EUCLIDIAN_SOLVED); // save test solution bitmap
            }
        }
        
        [TestMethod()]
        public void ManhattanAStarFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solvedMaze = m.Solve(new ManhattanAStarFrontier());
            Assert.IsNotNull(solvedMaze);

            if (MazeSolverTests.SAVE_TEST_SOLUTIONS)
            {
                solvedMaze.Save(MAZE_MANHATTAN_SOLVED); // save test solution bitmap
            }
        }
    }
}
