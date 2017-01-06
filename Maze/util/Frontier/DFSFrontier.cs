using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class DFSFrontier<T> : Frontier<T>
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

        public bool isEmpty()
        {
            return (nodes.Count == 0);
        }
    }
}
