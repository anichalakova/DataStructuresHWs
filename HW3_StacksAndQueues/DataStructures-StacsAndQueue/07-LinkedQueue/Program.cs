using System;

namespace _07_LinkedQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Dequeue();
            linkedQueue.Enqueue(5);
            linkedQueue.Enqueue(6);
            linkedQueue.Enqueue(7);
            Console.WriteLine(string.Join(" ",linkedQueue.ToArray()));
        }
    }
}
