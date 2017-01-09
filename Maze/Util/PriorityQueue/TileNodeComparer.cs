using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Util.PriorityQueue
{
    /// <summary>
    /// TileNode Comparer
    /// </summary>
    public class TileNodeComparer : IComparer<TileNode>
    {
        private static TileNodeComparer _instance;

        protected TileNodeComparer() { }

        public static TileNodeComparer Instance()
        {
            // Uses lazy initialization.
            // Note: NOT thread safe.
            if (_instance == null)
            {
                _instance = new TileNodeComparer();
            }

            return _instance;
        }

        /// <summary>
        /// Compare function used for TileNode comparison
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>   -1: x costs less than y
        ///              1: x costs greater than or equal to y</returns>
        public int Compare(TileNode x, TileNode y)
        {
            if(x.Cost < y.Cost)
            {
                return -1;
            }
            return 1;
        }
    }
}
