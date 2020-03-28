using System;

namespace Ferrari
{
    public class Program
    {
        public static void Main()
        {
            string driver = Console.ReadLine();
            var car = new Ferrari(driver);
            Console.WriteLine(car);
        }
    }
}
