using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BitArray64
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 arr = new BitArray64(5);
            arr.Add(20494202);
            arr.Add(204203);
            arr.Add(30494202);
            arr.Add(40494202);
            arr.Add(50494202);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            BitArray64 arr2 = new BitArray64(5);
            arr2.Add(20494202);
            arr2.Add(204203);
            arr2.Add(30494202);
            arr2.Add(40494202);
            arr2.Add(50494202);

            Console.WriteLine(arr.Equals(arr2));
            Console.WriteLine(arr.GetHashCode());

            arr2[0] = 1;
            Console.WriteLine("Check for equality: {0}",arr == arr2);

        }
    }

    class BitArray64 : IEnumerable<int>
    {
        ulong[] values;
        int pos;

        public BitArray64(int length)
        {
            values = new ulong[length];
            pos = 0;
        }

        public void Add(ulong value)
        {
            if (pos < values.Length)
            {
                values[pos] = value;
                pos++;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public int Length
        {
            get { return values.Length; }
        }

        public static bool operator ==(BitArray64 a, BitArray64 b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(BitArray64 a, BitArray64 b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        public ulong this[int i]
        {
            get { return values[i]; }
            set { values[i] = value; }
        }

        public override bool Equals(object obj)
        {
            BitArray64 lala = (BitArray64)obj;
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != lala[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                ulong hash = 19;
                foreach (var item in values)
                {
                    hash += (ulong)item.GetHashCode();
                    hash *= 23;
                }
                hash += (ulong)values.Length.GetHashCode();
                return (int)hash;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<int>)GetEnumerator();
        }
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return (IEnumerator<int>)GetEnumerator();
        }
        public BitArray64Enum GetEnumerator()
        {
            return new BitArray64Enum(values);
        }
    }

    class BitArray64Enum : IEnumerator
    {
        int position = -1;
        public ulong[] values;

        public BitArray64Enum(ulong[] values)
        {
            this.values = values;
        }

        public bool MoveNext()
        {
            position++;
            return (position < values.LongLength);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get
            {
                try
                {
                    return values[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
