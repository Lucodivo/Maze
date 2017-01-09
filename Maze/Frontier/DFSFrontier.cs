using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// A Frontier that simply uses LIFO stack structure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DFSFrontier<T> : IFrontier<T>
    {
        private Stack<T> nodes;

        public DFSFrontier()
        {
            nodes = new Stack<T>();
        }

        public void Enqueue(T element)
        {
            nodes.Push(element);
        }

        public T Dequeue()
        {
            return nodes.Pop();
        }

        public bool IsEmpty()
        {
            return (nodes.Count == 0);
        }

        public void Clear()
        {
            nodes.Clear();
        }
    }
}
