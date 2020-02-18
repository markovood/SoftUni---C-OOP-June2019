using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            // Problem 4: Random list
            var randList = new RandomList()
            {
                "Pesho",
                "Gosho",
                "Stamat",
                "Misho",
                "Todor"
            };

            Console.WriteLine(randList.RandomString());
        }
    }
}