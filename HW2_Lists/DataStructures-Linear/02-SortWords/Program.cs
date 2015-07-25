using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SortWords
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please, enter a sequence of words, separated by space:");
            var input = Console.ReadLine();
            var inputSplited = input.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var sequence = new List<string>();
            sequence.AddRange(inputSplited);
            sequence.Sort();
            Console.WriteLine(string.Join(", ", sequence.ToArray()));
        }
    }
}
