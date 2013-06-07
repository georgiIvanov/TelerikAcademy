using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PriorityQueue
{
    class Heap<T> where T : IComparable
    {
        List<T> heap;

        public Heap()
        {
            heap = new List<T>();
        }

        public Heap(int size)
        {
            heap = new List<T>(size);
        }

        public void Add(T value)
        {
            heap.Add(value);
            int index = heap.Count - 1;
            T movingValue = heap[index];
            int parentIndex = (index - 1) / 2;

            while (index > 0 && movingValue.CompareTo(heap[parentIndex]) > 0)
            {
                heap[index] = heap[parentIndex];
                index = parentIndex;
                parentIndex = (parentIndex - 1) / 2;
            }

            heap[index] = movingValue;
        }

        public void Pop()
        {
            int index = 0;
            heap[index] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            T movingValue = heap[index];

            int currentIndex = 0, leftIndex = 0, rightIndex = 0;

            while (index < heap.Count / 2)
            {
                leftIndex = 2 * index + 1;
                rightIndex = leftIndex + 1;
                if (rightIndex < heap.Count && heap[leftIndex].CompareTo(heap[rightIndex]) < 0 )
                {
                    currentIndex = rightIndex;
                }
                else
                {
                    currentIndex = leftIndex;
                }

                if (movingValue.CompareTo(heap[currentIndex]) > 0)
                {
                    break;
                }

                heap[index] = heap[currentIndex];
                index = currentIndex;
            }
            heap[index] = movingValue;
        }

        public T Peek
        {
            get
            {
                return heap[0];
            }
        }

        public int Count
        {
            get
            {
                return heap.Count;
            }
        }
    }
}
