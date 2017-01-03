using System;
using System.Drawing;
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
        private int x;
        private int y;
        private int cost;
        private TileNode prev;

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public int Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }

        public TileNode Prev
        {
            get
            {
                return prev;
            }

            set
            {
                prev = value;
            }
        }

        public TileNode(int x, int y, int cost, TileNode p)
        {
            this.X = x;
            this.Y = y;
            this.Cost = cost;
            this.Prev = p;
        }

        public TileNode(Point point, int cost, TileNode p) : this(point.X, point.Y, cost, p) { }

        public TileNode() : this(0, 0, 0, null) { }
    }
}
