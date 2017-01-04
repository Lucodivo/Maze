using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.util.PriorityQueue
{
    /// <summary>
    /// TileNode Comparer
    /// </summary>
    public class TileNodeComparer : IComparer<TileNode>
    {
        /// <summary>
        /// Compare function used for TileNode comparison
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>   >0: x costs more than y
        ///             0: x has an equal cost to y
        ///             &lt0: x costs less than y</returns>
        public int Compare(TileNode x, TileNode y)
        {
            return (x.Cost - y.Cost);
        }
    }
}
