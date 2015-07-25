using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_LongestSequence
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please, enter a sequence of integers, separated by space:");
            var input = Console.ReadLine();
            var inputSplited = input.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            int[] inputInts = Array.ConvertAll(inputSplited, int.Parse);
            var sequence = new List<int>();
            sequence.AddRange(inputInts);

            int countSame;
            int maxCountValue;
            var maxCount = FindMaxCount(sequence, out countSame, out maxCountValue);

            var maxCountSequence = new List<int>(Enumerable.Repeat(maxCountValue, maxCount));
            Console.WriteLine(string.Join(", ", maxCountSequence.ToArray()));
        }

        private static int FindMaxCount(List<int> sequence, out int countSame, out int maxCountValue)
        {
            countSame = 1;
            var maxCount = 1;
            maxCountValue = sequence[0];
            for (int i = 0; i < sequence.Count; i++)
            {
                if ((i < sequence.Count - 1) && (sequence[i] == sequence[i + 1]))
                {
                    countSame++;
                }
                else if (countSame > maxCount)
                {
                    maxCount = countSame;              
                    maxCountValue = sequence[i];
                    countSame = 1;
                }
                else
                {
                    countSame = 1;
                }
            }
            return maxCount;
        }
    }
}
