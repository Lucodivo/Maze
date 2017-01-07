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
        public T[] queue;
        public int count;
        public int capacity;
        IComparer<T> comparer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cap">Initial size of queue</param>
        /// <param name="comp"></param>
        public PriorityQueue(IComparer<T> comp, int cap)
        {
            this.capacity = cap;
            this.queue = new T[this.capacity];
            this.comparer = comp;
            this.count = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comp"></param>
        public PriorityQueue(IComparer<T> comp) : this(comp, 16) {  }

        /// <summary>
        /// Adds element to queue while maintaining minheap
        /// </summary>
        /// <param name="element">element to be added to queue</param>
        public void add(T element)
        {
            // Double the queue's capacity if it is currently full
            if (this.count == this.capacity)
            {
                doubleCapacity();
            }

            // add element to end of array and float it to it's correct position
            this.queue[this.count++] = element;
            heapifyUp();
        }

        /// <summary>
        /// Removes and returns smallest value node in queue
        /// </summary>
        public T remove()
        {
            // return and remove highest priority element if the queue is not empty
            if(this.count > 0)
            {

                T highestPriorityElement = this.queue[0];
                this.queue[0] = this.queue[--this.count];
                heapifyDown();
                return highestPriorityElement;
            }

            // return the default value if the queue is empty
            return default(T);
        }

        /// <summary>
        /// View the node with minimum value (does not remove node from queue
        /// </summary>
        /// <returns>current node with minimum value</returns>
        public T peek()
        {
            // return highest priority element if the queue is not empty
            if (count > 0)
            {
                return this.queue[0];
            }

            // return the default value if the queue is empty
            return default(T);
        }

        /// <summary>
        /// Place the node at the end of the array into its appropriate position
        /// </summary>
        private void heapifyUp()
        {
            int newIndex = this.count - 1;
            while (newIndex > 0)
            {
                int parentIndex = (newIndex - 1) / 2;
                if (this.comparer.Compare(this.queue[newIndex], this.queue[parentIndex]) < 0)
                {
                    queueSwap(newIndex, parentIndex);
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
        private void heapifyDown()
        {
            int rootIndex = 0;
            int firstChildlessIndex = this.count / 2;
            while (rootIndex < firstChildlessIndex)
            {
                int leftChildIndex = (rootIndex * 2) + 1;
                int rightChildIndex = (rootIndex * 2) + 2;
                if (this.comparer.Compare(this.queue[rootIndex], this.queue[leftChildIndex]) > 0
                    || this.comparer.Compare(this.queue[rootIndex], this.queue[rightChildIndex]) > 0)
                {
                    if (this.comparer.Compare(this.queue[leftChildIndex], this.queue[rightChildIndex]) > 0)
                    {
                        queueSwap(rootIndex, rightChildIndex);
                        rootIndex = rightChildIndex;
                    }
                    else
                    {
                        queueSwap(rootIndex, leftChildIndex);
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
        public void doubleCapacity()
        {
            T[] newQueue = new T[this.capacity * 2];
            Array.Copy(this.queue, newQueue, this.capacity);
            this.queue = newQueue;
            this.capacity *= 2;
        }

        /// <summary>
        /// Helper function for swapping values in queue
        /// </summary>
        private void queueSwap(int index1, int index2)
        {
            T tmp = this.queue[index1];
            this.queue[index1] = this.queue[index2];
            this.queue[index2] = tmp;
        }
    }
}
