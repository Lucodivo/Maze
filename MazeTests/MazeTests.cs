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
            m = new Maze(Maze.MAZE_PICTURE_1);
        }

        [TestMethod()]
        public void ColorTest()
        {
            Color c = m.getTopLeftPixel();

            byte expectedRed = 0;
            byte expectedGreen = 0;
            byte expectedBlue = 0;

            Assert.AreEqual(expectedRed, c.R);
            Assert.AreEqual(expectedGreen, c.G);
            Assert.AreEqual(expectedBlue, c.B);
        }
    }
}