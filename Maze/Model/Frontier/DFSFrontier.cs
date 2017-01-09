using System.Collections.Generic;

namespace Maze.Model.Frontier
{
    /// <summary>
    /// A Frontier that simply uses LIFO stack structure
    /// </summary>
    /// <typeparam name="T">type of nodes to be expanded</typeparam>
    public class DFSFrontier<T> : IFrontier<T>
    {
        // LIFO structure to hold nodes
        private Stack<T> nodes;

        public DFSFrontier()
        {
            nodes = new Stack<T>();
        }

        /// <summary>
        /// Returns the element to be expanded next
        /// </summary>
        public void Enqueue(T element)
        {
            nodes.Push(element);
        }

        /// <summary>
        /// Places an element in the frontier
        /// </summary>
        public T Dequeue()
        {
            return nodes.Pop();
        }

        /// <summary>
        /// Returns true if there are no elements in the frontier
        /// </summary>
        public bool IsEmpty()
        {
            return (nodes.Count == 0);
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
