using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures_Linear
{
    internal class SumAndAverage
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a sequence of integers, separated by space:");
            var input = Console.ReadLine();
            var inputSplited = input.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            int[] inputInts = Array.ConvertAll(inputSplited, int.Parse);
            var sequence = new List<int>();
            sequence.AddRange(inputInts);
            var sum = sequence.Sum();
            var average = sequence.Average();
            Console.WriteLine(string.Format("Sum={0}; Average={1}", sum, average));
        }
    }
}