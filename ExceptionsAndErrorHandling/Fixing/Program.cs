using System;

namespace Fixing
{
    public class Program
    {
        public static void Main()
        {
            string[] weekdays = new string[5];
            weekdays[0] = "Sunday";
            weekdays[1] = "Monday";
            weekdays[2] = "Tuesday";
            weekdays[3] = "Wednesday";
            weekdays[4] = "Thursday";

            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("You are trying to print item from non existing index!");
                }
            }
        }
    }
}
