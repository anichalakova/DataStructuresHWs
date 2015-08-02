using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures_TreeTraversal
{
    class Program
    {
        // The problem is solved according to the first homework assignment, which was later changed by Nakov
        static int nodesCount;
        static List<int>[] graph;

        static List<int>[] ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            nodesCount = n;
            graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] =
                    Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
            }
            return graph;
        }

        private static void PrintOutput(List<int> result)
        {
            if (result.Count == 1)
            {
                Console.WriteLine(result[0]);
            }
            else if (result.Count > 1)
            {
                Console.WriteLine("Forest is not a tree!");
            }
            else
            {
                Console.WriteLine("No root!");
            }
        }

        static void Main()
        {
            graph = ReadGraph();

            IList<int> allNodes = new List<int>();
            for (int i = 0; i <= nodesCount; i++)
            {
                allNodes.Add(i);
            }
            
            IList<int> parentNodes = new List<int>();
            IList<int> childNodes = new List<int>();
            for (int i = 0; i < nodesCount; i++)
            {
                parentNodes.Add(graph[i][0]);
                childNodes.Add(graph[i][1]);
            }

            var result = new List<int>();
            result = allNodes.Except(childNodes).ToList();
            PrintOutput(result);
        }
    }
}
