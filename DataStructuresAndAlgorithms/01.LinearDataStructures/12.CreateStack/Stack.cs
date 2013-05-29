using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CreateStack
{
    class Stack<T>
    {
        StackArray<T> array;

        public Stack()
        {
            array = new StackArray<T>();
        }

        public void Push(T value)
        {
            array.Push(value);
        }

        public T Peek()
        {
            return array.Peek();
        }

        public T Pop()
        {
            return array.Pop();
        }

    }
}
