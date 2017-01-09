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
    public class EuclidianAStarFrontier : AStarFrontier
    {
        public EuclidianAStarFrontier(TileNode finishTile = null, int initCap = 16, float hScale = 1.0f) : base(finishTile, initCap, hScale) { }

        public EuclidianAStarFrontier(TileNode finishTile, float hScale) : base(finishTile, hScale) { }

        protected override void Heuristic(ref TileNode element)
        {
            element.Value += (float) Math.Sqrt(Math.Pow((element.X - this.Goal.X), 2) +
                Math.Pow((element.Y - this.Goal.Y), 2));
        }
    }
}
