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
        public ManhattanAStarFrontier(TileNode finishTile) : base(finishTile) { }

        protected override void heuristic(ref TileNode element)
        {
            element.Cost += Math.Abs(this.goal.X - element.X);
            element.Cost += Math.Abs(this.goal.Y - element.Y);
        }
    }
}
