using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class ManhattanAStarFrontier : AStarFrontier
    {
        public ManhattanAStarFrontier(TileNode finishTile) : base(finishTile)
        {
        }

        protected override TileNode heuristic(TileNode element)
        {
            element.cost += Math.Abs(this.finishTile.x - element.x);
            element.cost += Math.Abs(this.finishTile.y - element.y);
            return element;
        }
    }
}
