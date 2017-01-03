using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    abstract class AStarFrontier : Frontier<TileNode>
    {
        PriorityQueue<TileNode> queue;
        protected TileNode finishTile;

        public AStarFrontier(TileNode finishTile)
        {
            this.finishTile = finishTile;
            queue = new PriorityQueue<TileNode>(new TileNodeComparer());
        }

        public TileNode Dequeue()
        {
            return queue.remove();
        }

        public void Enqueue(TileNode element)
        {
            element = heuristic(element);
            queue.add(element);
        }

        abstract protected TileNode heuristic(TileNode element);

        public bool isEmpty()
        {
            return (queue.count == 0);
        }
    }
}
