namespace RhombusOfStars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            DrawRhombus(n);
        }

        private static void DrawRhombus(int n)
        {
            // draw first half
            for (int i = 1; i <= n; i++)
            {
                PrintLine(i, n);
            }

            // draw second half
            for (int i = n - 1; i > 0; i--)
            {
                PrintLine(i, n);
            }
        }

        private static void PrintLine(int stars, int maxSpaces)
        {
            string spacePart = new string(' ', maxSpaces - stars);
            Console.Write(spacePart);
            for (int i = 0; i < stars; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}
