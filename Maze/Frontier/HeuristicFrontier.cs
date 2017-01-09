using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public abstract class HeuristicFrontier<T> : IFrontier<T>
    {
        private T goal;
        private float heuristicScale;

        protected T Goal
        {
            get
            {
                return goal;
            }

            set
            {
                goal = value;
            }
        }

        protected float HeuristicScale
        {
            get
            {
                return heuristicScale;
            }

            set
            {
                heuristicScale = value;
            }
        }

        public abstract void Clear();
        public abstract T Dequeue();
        public abstract void Enqueue(T element);
        public abstract bool IsEmpty();

        public void SetGoal(T goal)
        {
            this.Goal = goal;
        }

        public void SetScale(float hScale)
        {
            this.HeuristicScale = hScale;
        }
    }
}
