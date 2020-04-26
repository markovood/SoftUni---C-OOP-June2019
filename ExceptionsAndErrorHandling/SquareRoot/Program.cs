using System;

namespace SquareRoot
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                double numberSqrt = Math.Sqrt(number);
                if (double.IsNaN(numberSqrt))
                {
                    throw new ArgumentException();
                }

                Console.WriteLine(numberSqrt);
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }

        }
    }
}
