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
        static List<int> visited = new List<int>();
        static Dictionary<int, List<int>> friendsByNode = new Dictionary<int, List<int>>();
        static int maxPathLength;      

        private static void Main(string[] args)
        {
            ReadInputGraph();
            EnlistNodeConnections();

            var pathLength = 0;
            maxPathLength = 0;             
            DepthFirstSearch(rootNode, pathLength);

            Console.WriteLine("Nodes in longest path: {0}", maxPathLength);
        }

        private static void EnlistNodeConnections()
        {
            foreach (var edge in graph)
            {
                var node1 = edge[0];
                var node2 = edge[1];
                ConnectNodes(node1, node2);
                ConnectNodes(node2, node1);
            }
        }

        private static void ConnectNodes(int firstNode, int secondNode)
        {
            if (friendsByNode.ContainsKey(firstNode))
            {
                friendsByNode[firstNode].Add(secondNode);
            }
            else
            {
                var connectedNodes = new List<int>();
                connectedNodes.Add(secondNode);
                friendsByNode.Add(firstNode, connectedNodes);
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
            pathLength++;
            visited.Add(currentNode);
            //  Console.WriteLine("currentNode: " + currentNode);
            foreach (var friend in friendsByNode[currentNode])
            {
                //  Console.WriteLine("friend: " + friend);
                if (!visited.Contains(friend))
                {
                    DepthFirstSearch(friend, pathLength);
                }
            }
        //    Console.WriteLine("path =" + pathLength);
            if (maxPathLength < pathLength)
            {
                maxPathLength = pathLength;
            }
        }
    }
}
