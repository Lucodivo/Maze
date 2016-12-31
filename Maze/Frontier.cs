using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    interface Frontier<T>
    {
        void Enqueue(T element);
        T Dequeue();
        bool isEmpty();
    }
}
