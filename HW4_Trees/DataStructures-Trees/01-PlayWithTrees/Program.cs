using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures_Trees
{
    class Program
    {
        private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                Tree<int> parentNode = GetTreeNodeByValue(int.Parse(edge[0]));
                Tree<int> childNode = GetTreeNodeByValue(int.Parse(edge[1]));
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }
            
            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            var rootNode = FindRootNode().Value;
            Console.WriteLine(string.Format("Root node: {0}",rootNode ));

            var leafNodes = FindLeafNodes().Select(t => t.Value).ToArray().OrderBy(t => t);
            Console.WriteLine(string.Format("Leaf nodes: {0}", String.Join(", ", leafNodes)));

            var middleNodes = FindMiddleNodes().Select(t => t.Value).ToArray().OrderBy(t => t);
            Console.WriteLine(string.Format("Middle nodes: {0}", String.Join(", ", middleNodes)));

            var longestPath = FindLongestPath().Select(n => n.Value).ToArray().Reverse();
            Console.WriteLine(string.Format("Longest path: {0}", String.Join(" -> ", longestPath)));

            var paths = FindPathsBySum(pathSum);
            Console.WriteLine(string.Format("Paths with sum {0}: ", pathSum));
            foreach (var path in paths)
            {
                var nodesInPath = path.Select(n => n.Value).ToArray();
                Console.WriteLine( String.Join(" -> ",string.Join(" -> ", nodesInPath.Reverse()) ));
            }
        }

        internal static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }
            return nodeByValue[value];
        }

        internal static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(v => v.Parent == null);
            return rootNode;
        }

        internal static List<Tree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values.Where(n => n.Children.Count == 0).ToList();
            return leafNodes;
        }

        internal static List<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values.Where(n => n.Children.Count > 0 && n.Parent != null).ToList();
            return middleNodes;
        }

        internal static List<Tree<int>> FindLongestPath()
        {
            var nodeByPathlength = new List<KeyValuePair<int, Tree<int>>>();
            var leafNodes = FindLeafNodes();
            foreach (var node in leafNodes)
            {
                int pathLength = CountParentsToRoot(node);
                nodeByPathlength.Add(new KeyValuePair<int, Tree<int>>(pathLength, node));
            }

            var furthestLeafNode = nodeByPathlength.OrderByDescending(n => n.Key).FirstOrDefault().Value;
            var longestPath = new List<Tree<int>>();
            longestPath.Add(furthestLeafNode);
            while (furthestLeafNode.Parent != null)
            {
                furthestLeafNode = furthestLeafNode.Parent;
                longestPath.Add(furthestLeafNode);
            }

            return longestPath;
        }

        static int CountParentsToRoot(Tree<int> node)
        {
            int counter = 1;
            if (node.Parent != null)
            {
                counter = counter + CountParentsToRoot(node.Parent);
            }
            return counter;
        }


        internal static List<List<Tree<int>>> FindPathsBySum(int sum)
        {
            var nodeByPathSum = new List<KeyValuePair<int, Tree<int>>>();
            var leafNodes = FindLeafNodes();
            foreach (var node in leafNodes)
            {
                int pathSum = CalculatePathSum(node);
                nodeByPathSum.Add(new KeyValuePair<int, Tree<int>>(pathSum, node));
            }

            var leafNodesFromRequiredPaths = nodeByPathSum.Where(n => n.Key == sum).Select(n => n.Value).ToList();

            var paths = new List<List<Tree<int>>>();
            var currentPath = new List<Tree<int>>();
            for (int i = 0; i < leafNodesFromRequiredPaths.Count; i++)
            {
                var currentNode = leafNodesFromRequiredPaths[i];
                currentPath.Add(currentNode);
                while (currentNode.Parent != null)
                {
                    currentNode = currentNode.Parent;
                    currentPath.Add(currentNode);
                }

                paths.Add(new List<Tree<int>>(currentPath));
                currentPath.Clear();
            }

            return paths;
        }

        static int CalculatePathSum(Tree<int> node)
        {
            int sum = node.Value;
            if (node.Parent != null)
            {
                sum = sum + CalculatePathSum(node.Parent);
            }
            return sum;
        }
    }
}
