using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// A Frontier that simply uses FIFO queue structure
    /// </summary>
    /// <typeparam name="T">type of nodes to be expanded</typeparam>
    public class BFSFrontier<T> : IFrontier<T>
    {
        // FIFO structure to hold nodes
        private Queue<T> nodes;

        public BFSFrontier()
        {
            nodes = new Queue<T>();
        }

        /// <summary>
        /// Returns the element to be expanded next
        /// </summary>
        public T Dequeue()
        {
            if(nodes.Count > 0)
            {
                return this.nodes.Dequeue();
            } else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Places an element in the frontier
        /// </summary>
        public void Enqueue(T element)
        {
            this.nodes.Enqueue(element);
        }
        
        /// <summary>
        /// Returns true if there are no elements in the frontier
        /// </summary>
        public bool IsEmpty()
        {
            return (this.nodes.Count <= 0);
        }

        /// <summary>
        /// Clears the frontier of any data
        /// </summary>
        public void Clear()
        {
            nodes.Clear();
        }
    }
}
