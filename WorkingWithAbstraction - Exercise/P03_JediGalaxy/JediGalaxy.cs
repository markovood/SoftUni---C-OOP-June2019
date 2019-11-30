using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class JediGalaxy
    {
        public static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = InitializeMatrix(x, y);

            long sum = SumStars(matrix);
            Console.WriteLine(sum);
        }

        private static long SumStars(int[,] matrix)
        {
            long sumStars = 0;
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Let the Force be with you")
                {
                    break;
                }

                int[] ivo = ParseCoords(command);
                int[] evil = ParseCoords(Console.ReadLine());

                int evilX = evil[0];
                int evilY = evil[1];

                while (evilX >= 0 && evilY >= 0)
                {
                    if (ValidateCoords(matrix, evilX, evilY))
                    {
                        matrix[evilX, evilY] = 0;
                    }

                    evilX--;
                    evilY--;
                }

                int ivoX = ivo[0];
                int ivoY = ivo[1];

                while (ivoX >= 0 && ivoY < matrix.GetLength(1))
                {
                    if (ValidateCoords(matrix, ivoX, ivoY))
                    {
                        sumStars += matrix[ivoX, ivoY];
                    }

                    ivoY++;
                    ivoX--;
                }
            }

            return sumStars;
        }

        private static int[] ParseCoords(string value)
        {
            return value
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static bool ValidateCoords(int[,] matrix, int x, int y)
        {
            return x >= 0 && x < matrix.GetLength(0) &&
                y >= 0 && y < matrix.GetLength(1);
        }

        private static int[,] InitializeMatrix(int x, int y)
        {
            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            return matrix;
        }
    }
}
