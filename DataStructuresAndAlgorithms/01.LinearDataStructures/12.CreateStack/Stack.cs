using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CreateStack
{
    class Stack<T>
    {
        StackArray<T> array;
        int count;

        public Stack()
        {
            this.array = new StackArray<T>();
            this.count = 0;
        }

        public void Push(T value)
        {
            array.Push(value);
            count++;
        }

        public T Peek()
        {
            return array.Peek();
        }

        public T Pop()
        {
            if (count > 0)
            {
                count--;
            }
            else
            {
                throw new InvalidOperationException("Cannot pop empty stack.");
            }
            return array.Pop();
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

    }
}
