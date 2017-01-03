using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// Integer comparer
    /// </summary>
    public class IntComparer : IComparer<int>
    {
        /// <summary>
        /// Compare function used for integer comparison
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>   >0: means that x is greater than y
        ///             0: x is equal to y
        ///             &lt0: </returns>
        public int Compare(int x, int y)
        {
            return (x - y);
        }
    }
}
