using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// An A* Frontier that uses Chebyshev distance as its heuristic
    /// </summary>
    public class ChebyshevAStarFrontier : AStarFrontier
    {
        public ChebyshevAStarFrontier(TileNode finishTile = null, int initCap = 16, float hScale = 1.0f) : base(finishTile, initCap, hScale) { }

        public ChebyshevAStarFrontier(TileNode finishTile, float hScale) : base(finishTile, hScale) { }

        /// <summary>
        /// The heuristic uses chebyshev distance, which is biggest of the differences of y and x
        /// this is simply calculated by max(|x1 - x2|, |y1 - y2|)
        /// where Point(x1,y1) is an unexpanded node and Point(x2, y2) is the goal node
        /// </summary>
        /// <param name="element">The tilenode who's cost needs to be calculated</param>
        protected override void Heuristic(ref TileNode element)
        {
            element.Cost += element.Depth + Math.Max(Math.Abs(element.X - this.Goal.X), 
                Math.Abs(element.Y - this.Goal.Y)) * HeuristicScale;
        }
    }
}
