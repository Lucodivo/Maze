using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    abstract class AStarFrontier<T> : Frontier<T>
    {



        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T element)
        {
            throw new NotImplementedException();
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }
    }
}
