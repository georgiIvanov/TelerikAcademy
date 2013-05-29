using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CreateStack
{
    class StackArray<T>
    {
        T[] array;
        int top;

        public StackArray()
            :this(8)
        {
            this.top = 0;
        }

        public StackArray(int arraySize)
        {
            this.array = new T[arraySize];
        }

        public void Push(T value)
        {
            if (top == array.Length)
            {
                Extend();
            }

            array[top] = value;
            top++;
        }

        public T Pop()
        {
            int index = top - 1;
            top--;
            return array[index];
        }

        public T Peek()
        {
            return array[top - 1];
        }

        private void Extend()
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }
    }
}
