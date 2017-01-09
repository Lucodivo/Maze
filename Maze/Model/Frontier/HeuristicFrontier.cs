namespace Maze.Model.Frontier
{
    /// <summary>
    /// An abstract frontier class that uses heuristics to determine which
    /// nodes should be expanded next
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class HeuristicFrontier<T> : IFrontier<T>
    {
        // the goal node of the search
        private T goal;
        // multiplier for heuristic function, used mainly to break ties between nodes
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goal"></param>
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
