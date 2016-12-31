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
        // test maze image solved saving locations
        public const String MAZE_PICTURE_1_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze1solved.png";
        public const String MAZE_PICTURE_2_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze2solved.png";
        public const String MAZE_PICTURE_3_SOLVED = "..\\..\\..\\TestResults\\TestMazeSolutions\\maze3solved.png";

        private Maze m;

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

            Assert.AreEqual(expectedWidth, m.width);
            Assert.AreEqual(expectedHeight, m.height);

            // top left pixel location of start and finish squares
            int expectedStartX = 1;
            int expectedStartY = 396;
            int expectedFinishX = 221;
            int expectedFinishY = 397;

            Assert.AreEqual(expectedStartX, m.startTile.x);
            Assert.AreEqual(expectedStartY, m.startTile.y);
            Assert.AreEqual(expectedFinishX, m.finishTile.x);
            Assert.AreEqual(expectedFinishY, m.finishTile.y);
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
            // solvedMaze.Save(MAZE_PICTURE_1_SOLVED); // save test solution bitmap
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
            // solvedMaze.Save(MAZE_PICTURE_2_SOLVED); // save test solution bitmap
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
            // solvedMaze.Save(MAZE_PICTURE_3_SOLVED); // save test solution bitmap
        }
    }
}