using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// Interface used to determine which elements to expand when running a search
    /// </summary>
    /// <typeparam name="T">Type of element being expanded</typeparam>
    public interface IFrontier<T>
    {
        void Enqueue(T element);
        T Dequeue();
        bool isEmpty();
    }
}
