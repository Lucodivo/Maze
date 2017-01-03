using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class PriorityQueue<T>
    {
        public T[] queue;
        public int count;
        public int capacity;
        public IComparer<T> comparer;

        public PriorityQueue(int cap, IComparer<T> comp)
        {
            this.capacity = cap;
            this.queue = new T[this.capacity];
            this.count = 0;
            this.comparer = comp;
        }

        public PriorityQueue(IComparer<T> comp) : this(16, comp) { }

        public void add(T element)
        {
            if(this.count == this.capacity)
            {
                doubleCapacity();
            }

            this.queue[count++] = element;
            heapifyUp();
        }

        public T remove()
        {
            if(this.count > 0)
            {
                T highestPriorityElement = this.queue[0];
                this.queue[0] = this.queue[--this.count];
                heapifyDown();
                return highestPriorityElement;
            }

            return default(T);
        }

        public T peek()
        {
            if(count > 0)
            {
                return this.queue[0];
            }

            return default(T);
        }

        private void heapifyUp()
        {
            int newIndex = this.count - 1;
            while(newIndex > 0)
            {
                int parentIndex = (newIndex - 1) / 2;
                if(this.comparer.Compare(this.queue[newIndex], this.queue[parentIndex]) < 0)
                {
                    queueSwap(newIndex, parentIndex);
                    newIndex = parentIndex;
                } else
                {
                    return;
                }
            }
        }

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
                    } else
                    {
                        queueSwap(rootIndex, leftChildIndex);
                        rootIndex = leftChildIndex;
                    }
                } else
                {
                    return;
                }
            }
        }

        public void doubleCapacity()
        {
            T[] newQueue = new T[this.capacity * 2];
            Array.Copy(this.queue, newQueue, this.capacity);
            this.queue = newQueue;
            this.capacity *= 2;
        }

        private void queueSwap(int index1, int index2)
        {
            T tmp = this.queue[index1];
            this.queue[index1] = this.queue[index2];
            this.queue[index2] = tmp;
        }
    }
}
