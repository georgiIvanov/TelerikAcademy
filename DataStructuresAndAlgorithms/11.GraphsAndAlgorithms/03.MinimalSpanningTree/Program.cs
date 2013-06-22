using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightedGraph;

namespace _03.MinimalSpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int houses = 10;
            WeightedGraph<int> graph = new WeightedGraph<int>(houses);
            for (int i = 0; i < houses; i++)
            {
                graph.Add(i);
            }

            //edges are undirected
            graph.AttachEdge(0, 2, 7);
            graph.AttachEdge(0, 7, 10);
            graph.AttachEdge(1, 2, 2);
            graph.AttachEdge(1, 5, 5);
            graph.AttachEdge(3, 6, 6);
            graph.AttachEdge(3, 9, 5);
            graph.AttachEdge(4, 8, 5);
            graph.AttachEdge(5, 6, 1);
            graph.AttachEdge(7, 8, 2);
            graph.AttachEdge(8, 9, 2);

            string result = graph.MinimalSpanningTree();
            Console.WriteLine(result);
            
        }
    }
}
