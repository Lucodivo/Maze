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

            TileIndex expectedStartIndex = new TileIndex(1, 396);
            TileIndex expectedFinishIndex = new TileIndex(221, 397);

            Assert.AreEqual(expectedStartIndex, m.startPoint);
            Assert.AreEqual(expectedFinishIndex, m.finishPoint);
        }
    }
}