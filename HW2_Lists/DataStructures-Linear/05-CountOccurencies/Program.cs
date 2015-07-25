using System;
using System.Collections.Generic;

namespace _05_CountOccurencies
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
            var countOccurencies = 1;

            int currentInt;
            var countedInts = new List<int>();

            for (int i = 0; i < sequence.Count; i++)
            {
                currentInt = sequence[i];
                if (!countedInts.Exists(x => x == currentInt))
                {
                    for (int j = i + 1; j < sequence.Count; j++)
                    {
                        if (sequence[i] == sequence[j])
                        {
                            countOccurencies++;
                        }
                    }

                    Console.WriteLine(string.Format("{0} -> {1} times", currentInt, countOccurencies));
                    countOccurencies = 1;
                    countedInts.Add(currentInt);
                }
                
            }
        }
    }
}
