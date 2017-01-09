using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// A Frontier that uses Djikstras algorithm ( h(n) = 0 ). 
    /// When all edges are of equal cost, it essentially turns into a slower BFSFrontier
    /// 
    /// This class is perfect for testing the efficiency of the PriorityQueue class by comparing it
    /// with both BFSFrontier (which uses a simple queue) and other classes that extend AStarFrontier
    /// </summary>
    public class DjikstrasAStarFrontier : AStarFrontier
    {
        public DjikstrasAStarFrontier() : base(null, 16, 1.0f) { }

        /// <summary>
        /// Djikstras only takes into consideration the cost of expanding the node
        /// f(n) = g(n)
        /// </summary>
        /// <param name="element">The tilenode who's cost needs to be calculated</param>
        protected override void Heuristic(ref TileNode element)
        {
            element.Cost = element.Depth;
        }
    }
}
