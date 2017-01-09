using System;
using Maze.Util;

namespace Maze.Model.Frontier
{
    /// <summary>
    /// An A* Frontier that uses Manhattan Distance as its heuristic function
    /// </summary>
    public class ManhattanAStarFrontier : AStarFrontier
    {
        public ManhattanAStarFrontier(TileNode finishTile = null, int initCap = 16, float hScale = 1.0f) : base(finishTile, initCap, hScale) { }

        public ManhattanAStarFrontier(TileNode finishTile, float hScale) : base(finishTile, hScale) { }

        /// <summary>
        /// This heuristic function uses the Manhattan distance which can simply be calculated
        /// by a summation of difference in X coordinates and the difference in Y coordinates
        /// </summary>
        /// <param name="element">The tilenode who's cost needs to be calculated</param>
        protected override void Heuristic(ref TileNode element)
        {
            double hCost = ((Math.Abs(this.Goal.X - element.X) +
                   Math.Abs(this.Goal.Y - element.Y)) * this.HeuristicScale);
            element.Cost = element.Depth + hCost;
        }
    }
}
