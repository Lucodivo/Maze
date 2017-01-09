using System;
using Maze.Util;

namespace Maze.Model.Frontier
{
    /// <summary>
    /// An A* Frontier that uses Euclidean distance as its heuristic
    /// </summary>
    public class EuclideanAStarFrontier : AStarFrontier
    {
        public EuclideanAStarFrontier(TileNode finishTile = null, int initCap = 16, float hScale = 1.0f) : base(finishTile, initCap, hScale) { }

        public EuclideanAStarFrontier(TileNode finishTile, float hScale) : base(finishTile, hScale) { }

        /// <summary>
        /// The heuristic uses Euclidean distance, which is simply the distance between to points
        /// it is calculated by Sqrt(|x1 - x2|^2 + |y1 - y2|^2)
        /// where Point(x1,y1) is an unexpanded node and Point(x2, y2) is the goal node
        /// </summary>
        /// <param name="element">The tilenode who's cost needs to be calculated</param>
        protected override void Heuristic(ref TileNode element)
        {
            element.Cost += element.Depth + (float) Math.Sqrt(Math.Pow((element.X - this.Goal.X), 2) +
                Math.Pow((element.Y - this.Goal.Y), 2)) * HeuristicScale;
        }
    }
}
