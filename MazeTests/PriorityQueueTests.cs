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
        /// Tests expansion of capacity and 
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
    }
}
