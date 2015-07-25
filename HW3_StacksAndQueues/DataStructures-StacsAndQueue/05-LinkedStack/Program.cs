using System;

namespace _05_LinkedStack
{
    class Program
    {
        static void Main()
        {
            var linkedStack = new LinkedStack<int>();
            linkedStack.Push(7);
            linkedStack.Push(8);
            linkedStack.Push(9);
            Console.WriteLine(string.Join(" ", linkedStack.ToArray()));
            Console.WriteLine("Popped element: " + linkedStack.Pop().ToString());
            Console.WriteLine(string.Join(" ", linkedStack.ToArray()));
        }
    }
}
