using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// 
    /// </summary>
    public class ChebyshevAStarFrontier : AStarFrontier
    {
        public ChebyshevAStarFrontier(TileNode finishTile = null, int initCap = 16, float hScale = 1.0f) : base(finishTile, initCap, hScale) { }

        public ChebyshevAStarFrontier(TileNode finishTile, float hScale) : base(finishTile, hScale) { }

        protected override void Heuristic(ref TileNode element)
        {
            element.Value += Math.Max(Math.Abs(element.X - this.Goal.X), 
                Math.Abs(element.Y - this.Goal.Y));
        }
    }
}
