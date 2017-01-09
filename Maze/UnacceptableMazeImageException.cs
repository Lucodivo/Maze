using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// Exception used to signify that an image is not a suitable maze image
    /// </summary>
    public class UnacceptableMazeImageException : Exception
    {
        public UnacceptableMazeImageException() { }

        public UnacceptableMazeImageException(string msg) : base(msg) { }

        public UnacceptableMazeImageException(string msg, Exception inner) :
            base(msg, inner) { }
    }
}
