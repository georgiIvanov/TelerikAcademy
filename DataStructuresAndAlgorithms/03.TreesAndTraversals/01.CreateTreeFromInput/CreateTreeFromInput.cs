using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01.CreateTreeFromInput
{
    class CreateTreeFromInput
    {
        static void SetInput()
        {
            // there are also files input2.txt and input3.txt
            StreamReader sr = new StreamReader("..\\..\\input.txt");
            using (sr)
            {
                Console.SetIn(new StringReader(sr.ReadToEnd()));
            }
        }

        static void Main(string[] args)
        {
            // uncomment SetInput to load tree from file
            // SetInput();

            Dictionary<int, Node> dictionary = new Dictionary<int, Node>();

            ParseTree(dictionary);
            Node root = FindRoot(dictionary);

            Console.WriteLine("All nodes and they're children: ");
            foreach (var pair in dictionary)
            {
                Console.Write("{0}: ", pair.Key);
                foreach (var child in pair.Value.GetChildren)
                {
                    Console.Write("{0} ", child.Value);
                }
                Console.WriteLine();
            }

            // root
            Console.WriteLine("\nRoot value: {0}", root.Value);

            // leafs
            Console.WriteLine("\nLeafs: ");
            IEnumerable<Node> leafs = FindLeafNodes(root);
            foreach (var item in leafs)
            {
                Console.WriteLine(item.Value);
            }

            // middle nodes
            Console.WriteLine("\nMiddle nodes: ");
            IEnumerable<Node> middleNodes = FindMiddleNodes(root);
            foreach (var item in middleNodes)
            {
                Console.WriteLine(item.Value);
            }

            // longest path
            Console.WriteLine("\nLonges path: ");
            int steps = -1, maxSteps = 0;
            List<Node> path = new List<Node>(new Node[] { root });
            path.AddRange(LongestPath(root, ref steps, ref maxSteps));
            Console.WriteLine("Max steps: {0}\nNodes traversed:", maxSteps);
            foreach (var item in path)
            {
                Console.WriteLine(item.Value);
            }

            // all paths with sum S
            int s = 9;
            List<List<Node>> listOfPaths = new List<List<Node>>();
            PathsWithSumS(root, listOfPaths, new List<Node>(new Node[] { root }), root.Value, s);
            Console.WriteLine("\nPaths with sum of {0}:", s);
            foreach (var foundPath in listOfPaths)
            {
                foreach (var node in foundPath)
                {
                    Console.Write("{0} ", node.Value);
                }
                Console.WriteLine();
            }

            // all subtrees with sum S
            s = 6;
            List<Node> listOfSubTrees = new List<Node>();
            SubTreeWithSumS(root, listOfSubTrees, s);
            Console.WriteLine("\nSub trees with sum of {0}:", s);
            foreach (var foundTree in listOfSubTrees)
            {
                Console.Write("{0} ", foundTree.Value);
                PrintTree(foundTree);
                Console.WriteLine();
            }

        }

        private static void SubTreeWithSumS(Node root, List<Node> listOfSubTrees, int targetSum)
        {
            foreach (var item in root.GetChildren)
            {
                if (targetSum == CheckSubTreeSum(item, item.Value))
                {
                    listOfSubTrees.Add(item);
                }
                SubTreeWithSumS(item, listOfSubTrees, targetSum);
            }
        }

        private static int CheckSubTreeSum(Node subRoot, int sum)
        {
            foreach (var node in subRoot.GetChildren)
            {
                sum += CheckSubTreeSum(node, node.Value);
            }
            return sum;
        }

        private static void PrintTree(Node node)
        {
            foreach (var item in node.GetChildren)
            {
                Console.Write("{0} ", item.Value);
                PrintTree(item);
            }
        }

        private static void PathsWithSumS(Node root, List<List<Node>> listOfPaths, List<Node> pathSoFar, int currentSum, int targetSum)
        {
            if (currentSum == targetSum && CheckCurrentSum(pathSoFar, targetSum))
            {
                Node[] nodePath = new Node[pathSoFar.Count];
                pathSoFar.CopyTo(nodePath);
                listOfPaths.Add(new List<Node>(nodePath));
                pathSoFar.RemoveRange(1, pathSoFar.Count - 1);
            }

            foreach (var item in root.GetChildren)
            {
                pathSoFar.Add(item);
                PathsWithSumS(item, listOfPaths, pathSoFar, currentSum + item.Value, targetSum);
                if (pathSoFar.Count > 1)
                {
                    pathSoFar.RemoveAt(pathSoFar.Count - 1);
                }
            }

        }

        private static bool CheckCurrentSum(List<Node> path, int targetSum)
        {
            int sum = 0;
            foreach (var item in path)
            {
                sum += item.Value;
            }

            return sum == targetSum ? true : false;
        }

        private static List<Node> LongestPath(Node root, ref int steps, ref int maxSteps)
        {
            List<Node> path = new List<Node>();
            steps++;
            if (maxSteps < steps)
            {
                maxSteps = steps;
                path.Add(root);
            }

            foreach (var item in root.GetChildren)
            {
                path.AddRange(LongestPath(item, ref steps, ref maxSteps));
            }
            steps--;
            return path;
        }

        private static List<Node> FindLeafNodes(Node root)
        {
            List<Node> leafs = new List<Node>();
            List<Node> children = root.GetChildren;
            if (children.Count == 0)
            {
                leafs.Add(root);
            }

            foreach (var item in children)
            {
                leafs.AddRange(FindLeafNodes(item));

            }
            return leafs;
        }

        private static List<Node> FindMiddleNodes(Node root)
        {
            List<Node> middle = new List<Node>();
            List<Node> children = root.GetChildren;
            if (children.Count > 0 && root.HasParent == true)
            {
                middle.Add(root);
            }

            foreach (var item in children)
            {
                middle.AddRange(FindMiddleNodes(item));

            }
            return middle;
        }




        private static Node FindRoot(Dictionary<int, Node> dictionary)
        {
            foreach (var pair in dictionary)
            {
                if (!pair.Value.HasParent)
                {
                    return pair.Value;
                }
            }

            throw new ArgumentException("No root in built tree.");
        }

        private static void ParseTree(Dictionary<int, Node> dictionary)
        {
            int pairs = int.Parse(Console.ReadLine());
            for (int i = 0; i < pairs - 1; i++)
            {
                string[] input = Console.ReadLine().Split();
                int firstValue = int.Parse(input[0]);
                int secondValue = int.Parse(input[1]);

                if (dictionary.ContainsKey(firstValue))
                {
                    Node node = dictionary[firstValue];
                    Node secondNode;
                    if (dictionary.ContainsKey(secondValue))
                    {
                        secondNode = dictionary[secondValue];
                        secondNode.HasParent = true;
                    }
                    else
                    {
                        secondNode = new Node(secondValue);
                        dictionary.Add(secondValue, secondNode);
                    }

                    node.AddChild(secondNode);
                }
                else
                {
                    Node secondNode;
                    if (dictionary.ContainsKey(secondValue))
                    {
                        secondNode = dictionary[secondValue];
                        secondNode.HasParent = true;
                    }
                    else
                    {
                        secondNode = new Node(secondValue);
                        dictionary.Add(secondValue, secondNode);
                    }

                    Node firstNode = new Node(firstValue, secondNode);
                    dictionary.Add(firstValue, firstNode);
                }
            }
        }


    }
}
