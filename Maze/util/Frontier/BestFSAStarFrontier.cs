using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class BestFSAStarFrontier : AStarFrontier
    {
        public BestFSAStarFrontier(TileNode finishTile, int initCap = 16, float hScale = 1.0f) : base(finishTile, initCap, hScale) { }

        public BestFSAStarFrontier(TileNode finishTile, float hScale) : base(finishTile, hScale) { }

        protected override void heuristic(ref TileNode element)
        {
            element.Value = Math.Abs(this.goal.X - element.X);
            element.Value += Math.Abs(this.goal.Y - element.Y);
        }
    }
}
