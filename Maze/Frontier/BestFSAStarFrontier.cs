using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class BestFSAStarFrontier : AStarFrontier
    {
        public BestFSAStarFrontier(TileNode finishTile = null, int initCap = 16, float hScale = 1.0f) : base(finishTile, initCap, hScale) { }

        public BestFSAStarFrontier(TileNode finishTile, float hScale) : base(finishTile, hScale) { }

        protected override void Heuristic(ref TileNode element)
        {
            element.Value = Math.Abs(this.Goal.X - element.X);
            element.Value += Math.Abs(this.Goal.Y - element.Y);
        }
    }
}
