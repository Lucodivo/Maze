using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maze;

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
            PriorityQueue<int> pq = new PriorityQueue<int>(IntComparer.Instance());
            pq.Add(7);
            pq.Add(12321);
            pq.Add(7123);
            pq.Add(2333);
            pq.Add(4);
            pq.Add(34);
            pq.Add(687);
            pq.Add(9954);
            pq.Add(13);
            Assert.AreEqual(4, pq.Remove());
            Assert.AreEqual(7, pq.Remove());
            Assert.AreEqual(13, pq.Remove());
            pq.Add(64);
            pq.Add(128);
            pq.Add(344);
            pq.Add(6872);
            pq.Add(995);
            pq.Add(136);
            pq.Add(640);
            pq.Add(256);
            Assert.AreEqual(34, pq.Remove());
            Assert.AreEqual(64, pq.Remove());
            Assert.AreEqual(128, pq.Remove());
        }


        /// <summary>
        /// Tests that priority queue behaves properly using TileNodes
        /// </summary>
        [TestMethod()]
        public void TileNodePriorityQueueTest1()
        {
            PriorityQueue<TileNode> pq = new PriorityQueue<TileNode>(TileNodeComparer.Instance());
            TileNode testTile1 = new TileNode(0, 0, 0, null, 15);
            TileNode testTile2 = new TileNode(1, 0, 0, null, 9);
            TileNode testTile3 = new TileNode(32, 1, 0, null, 800);
            TileNode testTile4 = new TileNode(0, 0, 0, null, 312);
            TileNode testTile5 = new TileNode(2, 3, 0, null, 115);
            TileNode testTile6 = new TileNode(45, 600, 0, null, 17);
            TileNode testTile7 = new TileNode(3, 5, 0, null, 211);
            pq.Add(testTile1);
            pq.Add(testTile2);
            pq.Add(testTile3);
            pq.Add(testTile4);
            pq.Add(testTile5);
            pq.Add(testTile6);
            pq.Add(testTile7);
            Assert.AreEqual(testTile2, pq.Remove());
            Assert.AreEqual(testTile1, pq.Remove());
            Assert.AreEqual(testTile6, pq.Remove());
            TileNode testTile8 = new TileNode(3, 4234, 0, null, 34);
            TileNode testTile9 = new TileNode(1, 0, 0, null, 70);
            TileNode testTile10 = new TileNode(16, 1, 0, null, 811);
            TileNode testTile11 = new TileNode(0, 0, 0, null, 1);
            TileNode testTile12 = new TileNode(17, 37, 0, null, 101);
            TileNode testTile13 = new TileNode(5, 60, 0, null, 175);
            TileNode testTile14 = new TileNode(34, 5, 0, null, 2111);
            pq.Add(testTile8);
            pq.Add(testTile9);
            pq.Add(testTile10);
            pq.Add(testTile11);
            pq.Add(testTile12);
            pq.Add(testTile13);
            pq.Add(testTile14);
            Assert.AreEqual(testTile11, pq.Remove());
            Assert.AreEqual(testTile8, pq.Remove());
            Assert.AreEqual(testTile9, pq.Remove());
        }
    }
}
