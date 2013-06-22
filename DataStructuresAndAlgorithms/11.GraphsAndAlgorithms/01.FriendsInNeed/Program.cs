using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _01.FriendsInNeed
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();
            string[] initialParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int verticeCount = int.Parse(initialParams[0]);
            int streetsCount = int.Parse(initialParams[1]);
            int hospitalsCount = int.Parse(initialParams[2]);

            string[] hospitalParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] hospitalNumbers = new int[hospitalParams.Length];

            for (int i = 0; i < hospitalParams.Length; i++)
            {
                hospitalNumbers[i] = int.Parse(hospitalParams[i]);
            }

            Dictionary<int, Node> nodes = new Dictionary<int, Node>();
            List<int[]> allParams = new List<int[]>();

            for (int i = 0; i < streetsCount; i++)
            {
                string[] currentParams = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] currentNumbers = new int[currentParams.Length];

                for (int j = 0; j < currentParams.Length; j++)
                {
                    currentNumbers[j] = int.Parse(currentParams[j]);
                }

                allParams.Add(currentNumbers);

                if(!nodes.ContainsKey(currentNumbers[0]))
                {
                    nodes.Add(currentNumbers[0], new Node(currentNumbers[0], int.MaxValue));
                }

                if (!nodes.ContainsKey(currentNumbers[1]))
                {
                    nodes.Add(currentNumbers[1], new Node(currentNumbers[1], int.MaxValue));
                }
            }

            for (int i = 0; i < allParams.Count; i++)
            {
                int[] currentParams = allParams[i];

                if (graph.ContainsKey(nodes[currentParams[0]]))
                {
                    graph[nodes[currentParams[0]]].Add(new Connection(nodes[currentParams[1]], currentParams[2]));
                }
                else
                {
                    graph.Add(nodes[currentParams[0]], new List<Connection>() { new Connection(nodes[currentParams[1]], currentParams[2]) });
                }

                if (graph.ContainsKey(nodes[currentParams[1]]))
                {
                    graph[nodes[currentParams[1]]].Add(new Connection(nodes[currentParams[0]], currentParams[2]));
                }
                else
                {
                    graph.Add(nodes[currentParams[1]], new List<Connection>() { new Connection(nodes[currentParams[0]], currentParams[2]) });
                }
            }

            double bestSum = double.MaxValue;

            for (int i = 0; i < hospitalNumbers.Length; i++)
            {
                DijkstraAlgorithm(nodes[hospitalNumbers[i]], graph);

                double sum = 0;

                foreach (var item in graph)
                {
                    if (!hospitalNumbers.Contains(item.Key.PointID))
                    {
                        sum += item.Key.DijkstraDistance;
                    }
                }

                if (sum < bestSum)
                {
                    bestSum = sum;
                }
            }

            Console.WriteLine(bestSum);

        }

        static void DijkstraAlgorithm(Node source, Dictionary<Node, List<Connection>> graph)
        {
            BinaryHeap<Node> queue = new BinaryHeap<Node>();

            foreach (var node in graph)
            {
                if (source.PointID != node.Key.PointID)
                {
                    node.Key.DijkstraDistance = int.MaxValue;
                    queue.Add(node.Key);
                }
            }

            source.DijkstraDistance = 0;
            queue.Add(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Peek();

                if (currentNode.DijkstraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbour in graph[currentNode])
                {
                    int potentialDistance = currentNode.DijkstraDistance + neighbour.Distance;

                    if (potentialDistance < neighbour.Node.DijkstraDistance)
                    {
                        neighbour.Node.DijkstraDistance = potentialDistance;
                        Node next = new Node(neighbour.Node.PointID, potentialDistance);
                        queue.Add(next);
                    }
                    
                }

                queue.Remove();
            }

            
        }
    }

    class Connection
    {
        public Connection(Node node, int distance)
        {
            this.Node = node;
            this.Distance = distance;
        }
        public Node Node { get; set; }
        public int Distance { get; set; }
    }

    class Node : IComparable<Node>
    {
        public Node(int houseNumber, int dijkstraDistance)
        {
            this.PointID = houseNumber;
            this.DijkstraDistance = dijkstraDistance;
        }
        public int PointID { get; set; }
        public int DijkstraDistance { get; set; }

        public int CompareTo(Node other)
        {
            return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
        }

        public override int GetHashCode()
        {
            return this.PointID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Node);
        }

        public bool Equals(Node other)
        {
            return this.PointID.Equals(other.PointID);
        }
    }

    public class BinaryHeap<T> : ICollection<T> where T : IComparable<T>
    {
        private const int DefaultSize = 4;

        private T[] innerArray = new T[DefaultSize];
        private int count = 0;
        private int capacity = DefaultSize;
        private bool sorted;

        public BinaryHeap()
        {
        }

        private BinaryHeap(T[] data, int count)
        {
            this.Capacity = this.count;
            this.count = count;
            Array.Copy(this.innerArray, data, this.count);
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                int previousCapacity = this.capacity;
                this.capacity = Math.Max(value, this.count);

                if (this.capacity != previousCapacity)
                {
                    T[] temp = new T[this.capacity];
                    Array.Copy(this.innerArray, temp, this.count);
                    this.innerArray = temp;
                }
            }
        }

        public T Peek()
        {
            return this.innerArray[0];
        }

        public void Clear()
        {
            this.count = 0;
            this.innerArray = new T[this.capacity];
        }

        public void Add(T item)
        {
            if (this.count == this.capacity)
            {
                this.Capacity *= 2;
            }

            this.innerArray[this.count] = item;
            this.UpHeap();
            this.count++;
        }

        public T Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            T currentValue = this.innerArray[0];
            this.count--;
            this.innerArray[0] = this.innerArray[this.count];

            this.innerArray[this.count] = default(T);
            this.DownHeap();

            return currentValue;
        }

        public BinaryHeap<T> Copy()
        {
            return new BinaryHeap<T>(this.innerArray, this.count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.EnsureSort();

            for (int i = 0; i < this.count; i++)
            {
                yield return this.innerArray[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Contains(T item)
        {
            this.EnsureSort();

            return Array.BinarySearch<T>(this.innerArray, 0, this.count, item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.EnsureSort();
            Array.Copy(this.innerArray, array, this.count);
        }

        public bool Remove(T item)
        {
            this.EnsureSort();
            int i = Array.BinarySearch<T>(this.innerArray, 0, this.count, item);
            if (i < 0)
            {
                return false;
            }

            Array.Copy(this.innerArray, i + 1, this.innerArray, i, this.count - i);
            this.innerArray[this.count] = default(T);
            this.count--;

            return true;
        }

        private static int Parent(int index)
        {
            return (index - 1) >> 1;
        }

        private static int Child1(int index)
        {
            return (index << 1) + 1;
        }

        private static int Child2(int index)
        {
            return (index << 1) + 2;
        }

        private void UpHeap()
        {
            this.sorted = false;
            int currentCount = this.count;
            T item = this.innerArray[currentCount];
            int currentParrent = Parent(currentCount);

            while (currentParrent > -1 && item.CompareTo(this.innerArray[currentParrent]) < 0)
            {
                this.innerArray[currentCount] = this.innerArray[currentParrent];
                currentCount = currentParrent;
                currentParrent = Parent(currentCount);
            }

            this.innerArray[currentCount] = item;
        }

        private void DownHeap()
        {
            this.sorted = false;
            int n = 0;
            int p = 0;
            T item = this.innerArray[p];
            while (true)
            {
                int ch1 = Child1(p);
                if (ch1 >= this.count)
                {
                    break;
                }

                int ch2 = Child2(p);

                if (ch2 >= this.count)
                {
                    n = ch1;
                }
                else
                {
                    n = this.innerArray[ch1].CompareTo(this.innerArray[ch2]) < 0 ? ch1 : ch2;
                }

                if (item.CompareTo(this.innerArray[n]) > 0)
                {
                    this.innerArray[p] = this.innerArray[n];
                    p = n;
                }
                else
                {
                    break;
                }
            }

            this.innerArray[p] = item;
        }

        private void EnsureSort()
        {
            if (this.sorted)
            {
                return;
            }

            Array.Sort(this.innerArray, 0, this.count);
            this.sorted = true;
        }
    }

}
