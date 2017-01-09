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
        private int depth;
        private double value;
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

        public int Depth
        {
            get
            {
                return depth;
            }

            set
            {
                depth = value;
            }
        }

        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
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

        public TileNode(int x = 0, int y = 0, int depth = 0, TileNode p = null, double value = 0)
        {
            this.X = x;
            this.Y = y;
            this.Depth = depth;
            this.Value = value;
            this.Prev = p;
        }

        public TileNode(Point point, int depth, TileNode p) : this(point.X, point.Y, depth, p) { }

        public static bool HasSamePosition(TileNode tn1, TileNode tn2)
        {
            return (tn1.X == tn2.X && tn1.Y == tn2.Y);
        }
    }
}
