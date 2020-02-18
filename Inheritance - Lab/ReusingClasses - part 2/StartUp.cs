using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            var customStack = new StackOfStrings();
            customStack.Push("Pesho");
            customStack.Push("Gosho");
            customStack.Push("Todor");

            Console.WriteLine(customStack.IsEmpty());

            var range = new Stack<string>();
            range.Push("Misho");
            range.Push("Stamat");

            customStack.AddRange(range);
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
