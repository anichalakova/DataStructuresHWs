using System;

namespace _03_StackDataStructure
{
    class Program
    {
        static void Main()
        {
            var testStack = new ArrayStack<int>(3);
            testStack.Push(0);
            testStack.Push(1);
            testStack.Push(2);
            Console.WriteLine(string.Join(" ", testStack.ToArray()));
            testStack.Pop();
            Console.WriteLine(string.Join(" ", testStack.ToArray()));
            testStack.Push(3);
            testStack.Push(4);
            testStack.Push(5);
            testStack.Push(6);
            Console.WriteLine(string.Join(" ", testStack.ToArray()));
        }
    }
}
