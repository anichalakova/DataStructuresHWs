using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SinglyLinkedList
{
    class Program
    {
        private static void Main()
        {
            var list = new SinglyLinkedList<int>();

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.Add(5);
            list.Add(3);
            list.Add(2);
            list.Add(10, 1);
            list.Add(5);
            list.Add(99);
            Console.WriteLine("Count = {0}", list.Count);

            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            list.Remove(1);
            Console.WriteLine("Count = {0}", list.Count);
            list.ForEach(Console.WriteLine);
            Console.WriteLine("--------------------");

            Console.WriteLine(list.FirstIndexOf(5));
            Console.WriteLine("--------------------");

            Console.WriteLine(list.LastIndexOf(5));
        }
    }
}
