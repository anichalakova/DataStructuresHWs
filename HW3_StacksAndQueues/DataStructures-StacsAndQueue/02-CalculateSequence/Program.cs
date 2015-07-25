using System;
using System.Collections.Generic;

namespace _02_CalculateSequence
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer number N:");
            int seed = int.Parse(Console.ReadLine().TrimEnd());

            const int elementsToDisplay = 50;
            var sequence = new Queue<int>();
            var elements = new int[elementsToDisplay];
            
            int countElements = 0;
            int counter = 0;
            while (countElements < elementsToDisplay)
            {
                if (counter%3 == 0)
                {
                    sequence.Enqueue(seed +1);
                }
                else if ((counter % 3 == 1)||(counter == 1))
                {
                    sequence.Enqueue(2*seed + 1);
                }
                else if ((counter % 3 == 2) || (counter == 2))
                {
                    sequence.Enqueue(seed + 2);
                    elements[countElements] = seed;
                    countElements++;
                    seed = sequence.Dequeue();
                }
                counter++;
            }

            PrintElements(elements);
        }

        private static void PrintElements(int[] elements)
        {
            int elementsToDisplay;
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write(elements[i].ToString() + ' ');
            }
        }
    }
}
