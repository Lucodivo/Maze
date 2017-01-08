using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class UnacceptableMazeImageException : Exception
    {
        public UnacceptableMazeImageException() { }

        public UnacceptableMazeImageException(string msg) : base(msg) { }

        public UnacceptableMazeImageException(string msg, Exception inner) :
            base(msg, inner) { }
    }
}
