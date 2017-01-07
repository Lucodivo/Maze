using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// An A* Frontier that uses Manhattan Distance as its heuristic function
    /// </summary>
    class ManhattanAStarFrontier : AStarFrontier
    {
        public ManhattanAStarFrontier(TileNode finishTile, int initCap = 16, float hScale = 1.0f) : base(finishTile, initCap, hScale) { }

        public ManhattanAStarFrontier(TileNode finishTile, float hScale) : base(finishTile, hScale) { }

        protected override void heuristic(ref TileNode element)
        {
            double hCost = ((Math.Abs(this.goal.X - element.X) + 
                Math.Abs(this.goal.Y - element.Y)) * this.hScale);
            element.Value = element.Depth + hCost;
        }
    }
}
