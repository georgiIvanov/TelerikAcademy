using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class FriendsInNeed
{
    static void Main()
    {
        string[] nMH = ReadConsoleLine();
        int n = int.Parse(nMH[0]);
        int m = int.Parse(nMH[1]);
        int h = int.Parse(nMH[2]);

        Graph graph = new Graph(n);
        string[] hospitals = ReadConsoleLine();
        AddHospitalsToGraph(graph, hospitals);
        ReadEdges(m, graph);

        int sum = graph.GetBestHospital();
        Console.WriteLine(sum);
    }

    private static string[] ReadConsoleLine()
    {
        string inputLine = Console.ReadLine();
        string[] hospitals = inputLine.Split(' ');
        return hospitals;
    }

    private static void ReadEdges(int m, Graph graph)
    {
        for (int i = 0; i < m; i++)
        {
            string[] edgeArguments = ReadConsoleLine();
            int from = int.Parse(edgeArguments[0]);
            int to = int.Parse(edgeArguments[1]);
            int distance = int.Parse(edgeArguments[2]);
            graph.AddEdge(from, to, distance);
        }
    }

    private static void AddHospitalsToGraph(Graph graph, string[] hospitals)
    {
        foreach (var hospitalAsString in hospitals)
        {
            int hospital = int.Parse(hospitalAsString);
            graph.AddHospital(hospital);
        }
    }
}

class PriorityQueue<T> where T : IComparable<T>
{
    private OrderedBag<T> bag;

    public int Count
    {
        get
        {
            return bag.Count;
        }
        private set
        {
        }
    }

    public PriorityQueue()
    {
        bag = new OrderedBag<T>();
    }

    public void Enqueue(T element)
    {
        bag.Add(element);
    }

    public T Dequeue()
    {
        var element = bag.GetFirst();
        bag.RemoveFirst();
        return element;
    }

    public void Clear()
    {
        this.bag.Clear();
    }

    public T Peek()
    {
        var element = bag.GetFirst();
        return element;
    }
}

class Node : IComparable<Node>
{
    public int Vertex { get; set; }
    public int Disntace { get; set; }

    public Node(int vertex, int disntace)
    {
        this.Vertex = vertex;
        this.Disntace = disntace;
    }

    public int CompareTo(Node other)
    {
        return this.Disntace.CompareTo(other.Disntace);
    }
}

class Graph
{
    List<Node>[] vertices;
    HashSet<int> hospitals;
    private PriorityQueue<Node> queue;
    private HashSet<int> used;
    int[] distances;

    public Graph(int n)
    {
        vertices = new List<Node>[n];
        hospitals = new HashSet<int>();
    }

    public void AddEdge(int from, int to, int distance)
    {
        this.AddDirectedEdge(from - 1, to - 1, distance);
        this.AddDirectedEdge(to - 1, from - 1, distance);

    }

    private void AddDirectedEdge(int from, int to, int distance)
    {
        if (this.vertices[from] == null)
        {
            this.vertices[from] = new List<Node>();
        }

        var newNode = new Node(to, distance);
        this.vertices[from].Add(newNode);
    }

    public void AddHospital(int hospital)
    {
        this.hospitals.Add(hospital - 1);
    }

    public int GetBestHospital()
    {
        int bestDistance = int.MaxValue;

        foreach (int hospital in hospitals)
        {
            int[] distances = Dijkstra(hospital);
            int distance = Sum(distances);
            if (distance < bestDistance)
            {
                bestDistance = distance;
            }
        }

        return bestDistance;
    }

    private int Sum(int[] distances)
    {
        int sum = 0;
        for (int vertex = 0; vertex < distances.Length; vertex++)
        {
            if (!hospitals.Contains(vertex))
            {
                sum += distances[vertex];
            }
        }
        return sum;
    }

    private int[] Dijkstra(int hospital)
    {
        InitializeQueue();
        InitializeUsed();
        InitializeDistances(hospital);
        used.Add(hospital);
        Node startNode = new Node(hospital, 0);

        queue.Enqueue(startNode);
        Node best;
        while (queue.Count > 0)
        {
            best = queue.Dequeue();
            used.Add(best.Vertex);
            foreach (var nextNode in vertices[best.Vertex])
            {
                int newDistance = distances[best.Vertex] + nextNode.Disntace;
                if (distances[nextNode.Vertex] > newDistance)
                {
                    distances[nextNode.Vertex] = newDistance;
                    Node next = new Node(nextNode.Vertex, newDistance);
                    queue.Enqueue(next);
                }
            }
            ClearUsedVerticesFromQueue();
        }

        return distances;
    }

    private void InitializeDistances(int hospital)
    {
        if (distances == null)
        {
            distances = new int[vertices.Length];
        }
        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = int.MaxValue;
        }
        distances[hospital] = 0;
    }


    private void ClearUsedVerticesFromQueue()
    {
        while (queue.Count > 0 && used.Contains(queue.Peek().Vertex))
        {
            queue.Dequeue();
        }
    }

    private void InitializeUsed()
    {
        if (used == null)
        {
            used = new HashSet<int>();
        }
        else
        {
            used.Clear();
        }
    }

    private void InitializeQueue()
    {
        if (queue == null)
        {
            queue = new PriorityQueue<Node>();
        }
        else
        {
            queue.Clear();
        }
    }
}