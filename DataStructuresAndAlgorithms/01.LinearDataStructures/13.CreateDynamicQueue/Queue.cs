using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.CreateDynamicQueue
{
    class Queue<T>
    {
        QueueItem<T> firstItem;
        QueueItem<T> lastItem;
        int count;

        public Queue()
        {

        }

        public void Push(T value)
        {
            if (firstItem == null)
            {
                lastItem = new QueueItem<T>(value);
                firstItem = lastItem;
            }
            else
            {
                lastItem.PreviousItem = new QueueItem<T>(value);
                lastItem = lastItem.PreviousItem;
            }

            count++;
        }

        public T Peek()
        {
            return firstItem.Value;
        }

        public T Pop()
        {
            if (firstItem == null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            T valueToReturn = firstItem.Value;
            firstItem = firstItem.PreviousItem;
            return valueToReturn;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
    }
}
