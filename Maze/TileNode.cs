using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// Node used to traverse the pixels of a bitmap
    /// </summary>
    public class TileNode
    {
        public int x;
        public int y;
        public int cost;
        public TileNode prev;

        public TileNode(int x, int y, int cost, TileNode p)
        {
            this.x = x;
            this.y = y;
            this.cost = cost;
            this.prev = p;
        }
    }
}
