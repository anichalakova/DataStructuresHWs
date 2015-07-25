using System;
using System.Collections.Generic;

namespace RemoveOddOccurences
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
            var countOccurencies = 0;

            int currentInt;

            for (int i = 0; i < sequence.Count; i++)
            {
                currentInt = sequence[i];

                //-------------------- using simple algorythm -------------
                for (int j = 0; j < sequence.Count; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        countOccurencies++;
                    }
                }

                if (countOccurencies % 2 != 0)
                {
                    sequence.RemoveAll(x => x == currentInt);
                    i = i - 1;
                }
                countOccurencies = 0;

                //-------------- OR using the 10 times faster (for large data) algorythm below:----------
                //countOccurencies = 1;
                //var countedInts = new List<int>();
                //
                //if (!countedInts.Exists(x => x == currentInt))
                //{
                //    for (int j = i + 1; j < sequence.Count; j++)
                //    {
                //        if (sequence[i] == sequence[j])
                //        {
                //            countOccurencies++;
                //        }
                //    }
                //
                //    if (countOccurencies%2 != 0)
                //    {
                //        sequence.RemoveAll(x => x == currentInt);
                //        i = i - 1;
                //    }
                //    else
                //    {
                //        countedInts.Add(currentInt);
                //    }
                //    countOccurencies = 1;
                //}
            }
            Console.WriteLine(string.Join(" ", sequence.ToArray()));
        }
    }
}
