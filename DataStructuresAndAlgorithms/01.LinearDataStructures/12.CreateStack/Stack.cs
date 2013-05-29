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
            array = new StackArray<T>();
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
            count--;
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
