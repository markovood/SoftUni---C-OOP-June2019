using System;
using System.Collections.Generic;
using System.IO;

namespace EnterNumbers
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Enter 10 integers so that 1 < x < 100");
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    numbers.Add(ReadNumber(1, 100));
                }
                catch (InvalidDataException)
                {
                    numbers.Clear();
                    i = 0;
                    Console.WriteLine("Invalid number entered, please start again");
                }
            }

            Console.WriteLine($"You entered: {string.Join(' ', numbers)}");
        }

        private static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());
            if (number <= start || number >= end)
            {
                throw new InvalidDataException("number must be 1 < x < 100");
            }

            return number;
        }
    }
}
