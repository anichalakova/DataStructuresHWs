using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedList
{
    class Program
    {
        static void Main()
        {
            var list = new ReversedList<int>();

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            Console.WriteLine("Count = {0}", list.Count);

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            Console.WriteLine(list[3]);
            Console.WriteLine("--------------------");

            var element = list.Remove(3);
            Console.WriteLine("Element to remove: " + element);
            Console.WriteLine("Count = {0}", list.Count);
            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");
        }
    }
}
