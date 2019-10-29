namespace PointInRectangle
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] coordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var topLeft = new Point(coordinates[0], coordinates[1]);
            var bottomRight = new Point(coordinates[2], coordinates[3]);

            var rectangle = new Rectangle(topLeft, bottomRight);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] currentPoint = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var point = new Point(currentPoint[0], currentPoint[1]);
                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
