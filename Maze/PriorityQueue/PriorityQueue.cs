using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// A Min Heap structure that organizes the type as determined through the IComparer<T> interface
    /// </summary>
    /// <typeparam name="T">Type of element to be stored in a min heap. Must have corresponding class that implements IComparer</typeparam>
    public class PriorityQueue<T>
    {
        private T[] queue;
        private int count;
        public int capacity;
        IComparer<T> comparer;

        public int Count
        {
            get
            {
                return count;
            }

            private set
            {
                count = value;
            }
        }

        /// <param name="comp">comparer for elements being stored in priority queue</param>
        /// <param name="cap">Initial size of queue</param>
        public PriorityQueue(IComparer<T> comp, int cap)
        {
            this.capacity = cap;
            this.queue = new T[this.capacity];
            this.comparer = comp;
            this.Count = 0;
        }
        
        public PriorityQueue(IComparer<T> comp) : this(comp, 16) {  }

        /// <summary>
        /// Adds element to queue while maintaining minheap
        /// </summary>
        /// <param name="element">element to be added to queue</param>
        public void Add(T element)
        {
            // Double the queue's capacity if it is currently full
            if (this.Count == this.capacity)
            {
                DoubleCapacity();
            }

            // add element to end of array and float it to it's correct position
            this.queue[this.Count++] = element;
            HeapifyUp();
        }

        /// <summary>
        /// Removes and returns smallest value node in queue
        /// </summary>
        public T Remove()
        {
            // return and remove highest priority element if the queue is not empty
            if(this.Count > 0)
            {

                T highestPriorityElement = this.queue[0];
                this.queue[0] = this.queue[--this.Count];
                HeapifyDown();
                return highestPriorityElement;
            }

            // return the default value if the queue is empty
            return default(T);
        }

        /// <summary>
        /// View the node with minimum value (does not remove node from queue
        /// </summary>
        /// <returns>current node with minimum value</returns>
        public T Peek()
        {
            // return highest priority element if the queue is not empty
            if (Count > 0)
            {
                return this.queue[0];
            }

            // return the default value if the queue is empty
            return default(T);
        }

        /// <summary>
        /// Place the node at the end of the array into its appropriate position
        /// </summary>
        private void HeapifyUp()
        {
            int newIndex = this.Count - 1;
            while (newIndex > 0)
            {
                int parentIndex = (newIndex - 1) / 2;
                if (this.comparer.Compare(this.queue[newIndex], this.queue[parentIndex]) < 0)
                {
                    QueueSwap(newIndex, parentIndex);
                    newIndex = parentIndex;
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Place the node at the root in its appropriate position
        /// </summary>
        private void HeapifyDown()
        {
            int rootIndex = 0;
            int firstChildlessIndex = this.Count / 2;
            while (rootIndex < firstChildlessIndex)
            {
                int leftChildIndex = (rootIndex * 2) + 1;
                int rightChildIndex = leftChildIndex + 1;
                if (this.comparer.Compare(this.queue[rootIndex], this.queue[leftChildIndex]) > 0
                    || this.comparer.Compare(this.queue[rootIndex], this.queue[rightChildIndex]) > 0)
                {
                    if (this.comparer.Compare(this.queue[leftChildIndex], this.queue[rightChildIndex]) > 0)
                    {
                        QueueSwap(rootIndex, rightChildIndex);
                        rootIndex = rightChildIndex;
                    }
                    else
                    {
                        QueueSwap(rootIndex, leftChildIndex);
                        rootIndex = leftChildIndex;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Helper function to double the array size and capacity of priority queue
        /// </summary>
        public void DoubleCapacity()
        {
            T[] newQueue = new T[this.capacity * 2];
            Array.Copy(this.queue, newQueue, this.capacity);
            this.queue = newQueue;
            this.capacity *= 2;
        }

        /// <summary>
        /// Helper function for swapping values in queue
        /// </summary>
        private void QueueSwap(int index1, int index2)
        {
            T tmp = this.queue[index1];
            this.queue[index1] = this.queue[index2];
            this.queue[index2] = tmp;
        }

        /// <summary>
        /// Clears PriorityQueue of all data
        /// </summary>
        public void Clear()
        {
            this.Count = 0;
            Array.Clear(this.queue, 0, this.capacity);
        }
    }
}
