using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class BFSFrontier<T> : Frontier<T>
    {
        Queue<T> nodes;

        public BFSFrontier()
        {
            nodes = new Queue<T>();
        }


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

        public void Enqueue(T element)
        {
            this.nodes.Enqueue(element);
        }

        public bool isEmpty()
        {
            return (this.nodes.Count <= 0);
        }
    }
}
