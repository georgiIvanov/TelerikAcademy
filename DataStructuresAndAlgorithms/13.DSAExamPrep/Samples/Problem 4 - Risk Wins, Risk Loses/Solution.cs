using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // TestGenerator.GenerateTests(); return;

        string startCombination = Console.ReadLine();
        string finalCombination = Console.ReadLine();
        int forbiddenCombinationsCount = int.Parse(Console.ReadLine());
        List<string> forbiddenCombinations =
            new List<string>(forbiddenCombinationsCount);
        for (int i = 1; i <= forbiddenCombinationsCount; i++)
        {
            forbiddenCombinations.Add(Console.ReadLine());
        }

        LowestButtonsCountFinder finder = new LowestButtonsCountFinder(
            startCombination, finalCombination, forbiddenCombinations);

        Console.WriteLine(finder.Find() );
    }
}

class LowestButtonsCountFinder
{
    const int MaxNumber = 99999;
    const int WheelsCount = 5;
    private readonly int startEdge;
    private readonly int endEdge;
    private readonly bool[] isForbiddenEdge;
    private readonly int[] powerOf10;

    public LowestButtonsCountFinder(string startCombination, string finalCombination, List<string> forbiddenCombinations)
    {
        powerOf10 = new int[WheelsCount];
        powerOf10[0] = 1;
        for (int i = 1; i < WheelsCount; i++)
        {
            powerOf10[i] = powerOf10[i - 1] * 10;
        }
        this.startEdge = int.Parse(startCombination);
        this.endEdge = int.Parse(finalCombination);
        this.isForbiddenEdge = new bool[MaxNumber + 1]; // All false by default
        foreach (string forbiddenCombination in forbiddenCombinations)
        {
            this.isForbiddenEdge[int.Parse(forbiddenCombination)] = true;
        }
    }

    public int Find()
    {
        int result = BFS(this.startEdge, this.endEdge);
        return result;
    }

    private int BFS(int startEdge, int endEdge)
    {
        bool[] used = new bool[MaxNumber + 1];
        int level = 0;
        Queue<int> nodesQueue = new Queue<int>();
        nodesQueue.Enqueue(startEdge);
        while (nodesQueue.Count > 0)
        {
            Queue<int> nextLevelNodes = new Queue<int>();
            level++;
            while (nodesQueue.Count > 0)
            {
                int node = nodesQueue.Dequeue();
                if (node == endEdge)
                {
                    return level - 1;
                }

                // Pressing the left button
                for (int i = 0; i < WheelsCount; i++)
                {
                    int newNode = node;
                    int digit = (node / powerOf10[i]) % 10;
                    if (digit == 9)
                    {
                        newNode -= 9 * powerOf10[i];
                    }
                    else
                    {
                        newNode += powerOf10[i];
                    }
                    if (used[newNode]) continue;
                    if (isForbiddenEdge[newNode]) continue;
                    used[newNode] = true;
                    nextLevelNodes.Enqueue(newNode);
                }

                // Pressing the right button
                for (int i = 0; i < WheelsCount; i++)
                {
                    int newNode = node;
                    int digit = (node / powerOf10[i]) % 10;
                    if (digit == 0)
                    {
                        newNode += 9 * powerOf10[i];
                    }
                    else
                    {
                        newNode -= powerOf10[i];
                    }
                    if (used[newNode]) continue;
                    if (isForbiddenEdge[newNode]) continue;
                    used[newNode] = true;
                    nextLevelNodes.Enqueue(newNode);
                }
            }
            nodesQueue = nextLevelNodes;
        }
        return -1;
    }
}