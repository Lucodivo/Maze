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
        private Maze m;

        [TestInitialize()]
        public void Initialize()
        {
            ///
        }

        [TestMethod()]
        public void Maze1_Initialized_Test()
        {
            m = new Maze(new Bitmap(Maze.MAZE_PICTURE_1));

            int expectedWidth = 441;
            int expectedHeight = 441;

            Assert.AreEqual(expectedWidth, m.width);
            Assert.AreEqual(expectedHeight, m.height);

            int expectedStartX = 1;
            int expectedStartY = 396;
            int expectedFinishX = 221;
            int expectedFinishY = 397;

            Assert.AreEqual(expectedStartX, m.startTile.x);
            Assert.AreEqual(expectedStartY, m.startTile.y);
            Assert.AreEqual(expectedFinishX, m.finishTile.x);
            Assert.AreEqual(expectedFinishY, m.finishTile.y);
        }
    }
}