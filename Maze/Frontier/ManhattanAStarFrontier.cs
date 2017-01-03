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
            element.Cost += Math.Abs(this.finishTile.X - element.X);
            element.Cost += Math.Abs(this.finishTile.Y - element.Y);
            return element;
        }
    }
}
