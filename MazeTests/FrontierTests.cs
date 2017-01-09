using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeTests
{
    [TestClass()]
    public class FrontierTests
    {

        [TestMethod()]
        public void BestFSAStarFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solution = m.Solve(new BestFSAStarFrontier());
            Assert.IsNotNull(solution);
        }

        [TestMethod()]
        public void BFSFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solution = m.Solve(new BFSFrontier<TileNode>());
            Assert.IsNotNull(solution);
        }

        [TestMethod()]
        public void ChebyshevAStarFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solution = m.Solve(new ChebyshevAStarFrontier());
            Assert.IsNotNull(solution);
        }

        [TestMethod()]
        public void DFSFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solution = m.Solve(new DFSFrontier<TileNode>());
            Assert.IsNotNull(solution);
        }

        [TestMethod()]
        public void DjikstrasAStarFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solution = m.Solve(new DjikstrasAStarFrontier());
            Assert.IsNotNull(solution);
        }

        [TestMethod()]
        public void EuclidianAStarFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solution = m.Solve(new EuclidianAStarFrontier());
            Assert.IsNotNull(solution);
        }

        [TestMethod()]
        public void ManhattanAStarFrontier_Test()
        {
            MazeSolver m = new MazeSolver(new Bitmap(MazeSolverTests.MAZE_PICTURE_1));
            Bitmap solution = m.Solve(new ManhattanAStarFrontier());
            Assert.IsNotNull(solution);
        }
    }
}
