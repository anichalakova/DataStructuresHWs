using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_RoundDance
{
    class Program
    {
        static int edgesCount;
        static int rootNode;
        static List<int>[] graph;
        static Dictionary<int, int> pathLengthByNode = new Dictionary<int, int>();
        static Dictionary<int, List<int>> friendsByNode = new Dictionary<int, List<int>>();
        static int maxPathLength;      

        private static void Main(string[] args)
        {
            ReadInputGraph();
            FindConnectionsBetweenNodes();

            pathLengthByNode.Add(rootNode, 0);
            var pathLength = 0;
            maxPathLength = 0;
            foreach (var friend in friendsByNode[rootNode])
            {
                DepthFirstSearch(friend, pathLength);
            }
            
            Console.WriteLine("Nodes in longest path: {0}", maxPathLength + 1);
        }

        private static void FindConnectionsBetweenNodes()
        {
            foreach (var edge in graph)
            {
                var node1 = edge[0];
                var node2 = edge[1];
                if (friendsByNode.ContainsKey(node1))
                {
                    friendsByNode[node1].Add(node2);
                }
                else
                {
                    var connectedNodes = new List<int>();
                    connectedNodes.Add(node2);
                    friendsByNode.Add(node1, connectedNodes);
                }

                if (friendsByNode.ContainsKey(node2))
                {
                    friendsByNode[node2].Add(node1);
                }
                else
                {
                    var connectedNodes = new List<int>();
                    connectedNodes.Add(node1);
                    friendsByNode.Add(node2, connectedNodes);
                }
            }
        }

        private static void ReadInputGraph()
        {
            edgesCount = int.Parse(Console.ReadLine());
            rootNode = int.Parse(Console.ReadLine());

            graph = new List<int>[edgesCount];
            for (int i = 0; i < edgesCount; i++)
            {
                graph[i] =
                    Console.ReadLine()
                        .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
            }
        }

        static void DepthFirstSearch(int currentNode, int pathLength)
        {
            pathLengthByNode.Add(currentNode, pathLength);
            pathLength++;
                foreach (var friend in friendsByNode[currentNode])
                {
                    if (!pathLengthByNode.ContainsKey(friend))
                    {
                        DepthFirstSearch(friend, pathLength);
                    }
                }

            if (maxPathLength < pathLength)
            {
                maxPathLength = pathLength;
            }
        }
    }
}
