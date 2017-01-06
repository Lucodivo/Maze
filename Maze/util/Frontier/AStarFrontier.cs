using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// An abstract class that uses the A* algorithm to provide a Frontier of TileNodes
    /// to be expanded. The heuristic function must be implemented in the concrete class
    /// </summary>
    abstract class AStarFrontier : Frontier<TileNode>
    {
        PriorityQueue<TileNode> queue;
        protected TileNode goal;

        /// <summary>
        /// Constructor initializes PriorityQueue
        /// </summary>
        /// <param name="goal">The goal to be used for the heurstic function</param>
        public AStarFrontier(TileNode goal)
        {
            this.goal = goal;
            queue = new PriorityQueue<TileNode>(new TileNodeComparer());
        }

        /// <summary>
        /// Returns the next TileNode in the Frontier to be expanded
        /// </summary>
        public TileNode Dequeue()
        {
            return queue.remove();
        }

        /// <summary>
        /// Manipulates the Tilenode passed using a heuristic function and adds it to Frontier
        /// </summary>
        /// <param name="element">TileNode being added to Frontier</param>
        public void Enqueue(TileNode element)
        {
            heuristic(ref element);
            queue.add(element);
        }

        /// <summary>
        /// Heuristic function to manipulate the cost of a TileNode
        /// </summary>
        /// <param name="element">TileNode who's cost will be changed</param>
        abstract protected void heuristic(ref TileNode element);

        /// <summary>
        /// Returns true if the Frontier contains no TileNodes
        /// </summary>
        public bool isEmpty()
        {
            return (queue.count == 0);
        }
    }
}
