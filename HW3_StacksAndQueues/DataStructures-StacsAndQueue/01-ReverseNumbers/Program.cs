using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures_StacsAndQueue
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter several integers, separated by a space:");
            var inputString = Console.ReadLine().TrimEnd(' ');
            var inputArray = inputString.Split(' ');
            var numbersStack = new Stack<int>();

            int currentInt;
            bool result = true;

            for (int i = 0; i < inputArray.Length; i++)
            {
                result = Int32.TryParse(inputArray[i], out currentInt);

                if (!result)
                {
                    Console.WriteLine("Empty or invalid number!");
                    break;
                }
                numbersStack.Push(currentInt);
            }

            if (result)
            {
                var numbersStackCount = numbersStack.Count();
                
                for (int i = 0; i < numbersStackCount; i++)
                {
                    Console.Write(numbersStack.Pop().ToString()+' ');
                }
            }
        }
    }
}
