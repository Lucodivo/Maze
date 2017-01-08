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
    abstract class AStarFrontier : IFrontier<TileNode>
    {
        PriorityQueue<TileNode> queue;
        protected TileNode goal;
        protected float hScale;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="initCap"></param>
        /// <param name="hScale"></param>
        public AStarFrontier(TileNode goal, int initCap = 16, float hScale = 1.0f)
        {
            this.goal = goal;
            this.hScale = hScale;
            queue = new PriorityQueue<TileNode>(TileNodeComparer.Instance(), initCap);
        }

        public AStarFrontier(TileNode goal, float hScale) : this(goal, 16, hScale) { }

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
