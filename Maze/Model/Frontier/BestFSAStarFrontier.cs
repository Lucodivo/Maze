using System;
using Maze.Util;

namespace Maze.Model.Frontier
{
    /// <summary>
    /// Best First Search Frontier constructs a frontier using a greedy algorithm
    /// The cost to get to the current node is discarded and only the heuristic function is used
    /// f(n) = h(n)
    /// </summary>
    public class BestFSAStarFrontier : AStarFrontier
    {
        public BestFSAStarFrontier(TileNode finishTile = null, int initCap = 16, float hScale = 1.0f) : base(finishTile, initCap, hScale) { }

        public BestFSAStarFrontier(TileNode finishTile, float hScale) : base(finishTile, hScale) { }

        /// <summary>
        /// Best First Search uses the heuristic value as the cost and only that value
        /// This Best First Search uses the Manhattan distance heuristic
        /// f(n) = h(n)
        /// </summary>
        /// <param name="element">The tilenode who's cost needs to be calculated</param>
        protected override void Heuristic(ref TileNode element)
        {
            element.Cost = Math.Abs(this.Goal.X - element.X);
            element.Cost += Math.Abs(this.Goal.Y - element.Y);
        }
    }
}
