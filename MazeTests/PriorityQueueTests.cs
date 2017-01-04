using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maze;
using Maze.util.PriorityQueue;

namespace MazeTests
{
    [TestClass()]
    public class PriorityQueueTests
    {
        /// <summary>
        /// Tests PriorityQueue's expansion and that it functions properly
        /// as a min heap
        /// </summary>
        [TestMethod()]
        public void IntPriorityQueueTest1()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>(new IntComparer());
            pq.add(7);
            pq.add(12321);
            pq.add(7123);
            pq.add(2333);
            pq.add(4);
            pq.add(34);
            pq.add(687);
            pq.add(9954);
            pq.add(13);
            Assert.AreEqual(4, pq.remove());
            Assert.AreEqual(7, pq.remove());
            Assert.AreEqual(13, pq.remove());
            pq.add(64);
            pq.add(128);
            pq.add(344);
            pq.add(6872);
            pq.add(995);
            pq.add(136);
            pq.add(640);
            pq.add(256);
            Assert.AreEqual(34, pq.remove());
            Assert.AreEqual(64, pq.remove());
            Assert.AreEqual(128, pq.remove());
        }


        /// <summary>
        /// Tests that priority queue behaves properly using TileNodes
        /// </summary>
        [TestMethod()]
        public void TileNodePriorityQueueTest1()
        {
            PriorityQueue<TileNode> pq = new PriorityQueue<TileNode>(new TileNodeComparer());
            TileNode testTile1 = new TileNode(0, 0, 15, null);
            TileNode testTile2 = new TileNode(1, 0, 9, null);
            TileNode testTile3 = new TileNode(32, 1, 800, null);
            TileNode testTile4 = new TileNode(0, 0, 312, null);
            TileNode testTile5 = new TileNode(2, 3, 115, null);
            TileNode testTile6 = new TileNode(45, 600, 17, null);
            TileNode testTile7 = new TileNode(3, 5, 211, null);
            pq.add(testTile1);
            pq.add(testTile2);
            pq.add(testTile3);
            pq.add(testTile4);
            pq.add(testTile5);
            pq.add(testTile6);
            pq.add(testTile7);
            Assert.AreEqual(testTile2, pq.remove());
            Assert.AreEqual(testTile1, pq.remove());
            Assert.AreEqual(testTile6, pq.remove());
            TileNode testTile8 = new TileNode(3, 4234, 34, null);
            TileNode testTile9 = new TileNode(1, 0, 70, null);
            TileNode testTile10 = new TileNode(16, 1, 811, null);
            TileNode testTile11 = new TileNode(0, 0, 1, null);
            TileNode testTile12 = new TileNode(17, 37, 101, null);
            TileNode testTile13 = new TileNode(5, 60, 175, null);
            TileNode testTile14 = new TileNode(34, 5, 2111, null);
            pq.add(testTile8);
            pq.add(testTile9);
            pq.add(testTile10);
            pq.add(testTile11);
            pq.add(testTile12);
            pq.add(testTile13);
            pq.add(testTile14);
            Assert.AreEqual(testTile11, pq.remove());
            Assert.AreEqual(testTile8, pq.remove());
            Assert.AreEqual(testTile9, pq.remove());
        }
    }
}
