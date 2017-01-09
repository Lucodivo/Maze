using Maze.Util;
using Maze.Util.PriorityQueue;

namespace Maze.Model.Frontier
{
    /// <summary>
    /// An abstract class that uses the A* algorithm to provide a Frontier of TileNodes
    /// to be expanded. The heuristic function must be implemented in the concrete class.
    /// </summary>
    public abstract class AStarFrontier : HeuristicFrontier<TileNode>
    {
        // queue to organize track the minimum TileNode
        protected PriorityQueue<TileNode> queue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goal">TileNode that represents the goal of the search</param>
        /// <param name="initCap">Desired initial capacity of the frontier</param>
        /// <param name="hScale">Multiplier for heuristic function</param>
        public AStarFrontier(TileNode goal = default(TileNode), int initCap = 16, float hScale = 1.0f)
        {
            this.Goal = goal;
            this.HeuristicScale = hScale;
            queue = new PriorityQueue<TileNode>(TileNodeComparer.Instance(), initCap);
        }

        public AStarFrontier(TileNode goal, float hScale) : this(goal, 16, hScale) { }

        /// <summary>
        /// Returns the next TileNode in the Frontier to be expanded
        /// </summary>
        public override TileNode Dequeue()
        {
            return queue.Remove();
        }

        /// <summary>
        /// Manipulates the Tilenode passed using a heuristic function and adds it to Frontier
        /// </summary>
        /// <param name="element">TileNode being added to Frontier</param>
        public override void Enqueue(TileNode element)
        {
            Heuristic(ref element);
            queue.Add(element);
        }

        /// <summary>
        /// Heuristic function to manipulate the cost of a TileNode
        /// f(n) = g(n) + h(n)
        /// </summary>
        /// <param name="element">TileNode who's cost will be changed</param>
        abstract protected void Heuristic(ref TileNode element);

        /// <summary>
        /// Returns true if the Frontier contains no TileNodes
        /// </summary>
        public override bool IsEmpty()
        {
            return (queue.Count == 0);
        }

        /// <summary>
        /// Clears the priority queue of all data
        /// </summary>
        public override void Clear()
        {
            queue.Clear();
        }
    }
}
