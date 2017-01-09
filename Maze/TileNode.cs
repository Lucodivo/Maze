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
        // node's coordinates in the maze
        private int x;
        private int y;
        // current cost to reach the node
        private int depth;
        // expected cost to reach the goal
        private double cost;
        // node that added this node to a frontier
        private TileNode prev;

        public int X
        {
            get
            {
                return x;
            }

            private set
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

            private set
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

            private set
            {
                depth = value;
            }
        }

        public double Cost
        {
            get
            {
                return cost;
            }

            set
            {
                this.cost = value;
            }
        }

        public TileNode Prev
        {
            get
            {
                return prev;
            }

            private set
            {
                prev = value;
            }
        }

        public TileNode(int x = 0, int y = 0, int depth = 0, TileNode p = null, double value = 0)
        {
            this.X = x;
            this.Y = y;
            this.Depth = depth;
            this.Cost = value;
            this.Prev = p;
        }

        public TileNode(Point point, int depth, TileNode p) : this(point.X, point.Y, depth, p) { }

        /// <summary>
        /// returns true if to TileNode objects share the same coordinates
        /// </summary>
        public static bool HasSamePosition(TileNode tn1, TileNode tn2)
        {
            return (tn1.X == tn2.X && tn1.Y == tn2.Y);
        }
    }
}
