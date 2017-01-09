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
    public class ManhattanAStarFrontier : AStarFrontier
    {
        public ManhattanAStarFrontier(TileNode finishTile = null, int initCap = 16, float hScale = 1.0f) : base(finishTile, initCap, hScale) { }

        public ManhattanAStarFrontier(TileNode finishTile, float hScale) : base(finishTile, hScale) { }

        protected override void Heuristic(ref TileNode element)
        {
            double hCost = ((Math.Abs(this.Goal.X - element.X) + 
                Math.Abs(this.Goal.Y - element.Y)) * this.hScale);
            element.Value = element.Depth + hCost;
        }
    }
}
