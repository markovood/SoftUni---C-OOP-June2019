using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random generator;
        private ConsoleColor foodColor;

        protected Food(Wall wall, char foodSymbol, int points, ConsoleColor foodColor = ConsoleColor.White) :
            base(wall.LeftX, wall.TopY)
        {
            this.generator = new Random();
            this.wall = wall;
            this.FoodSymbol = foodSymbol;
            this.FoodPoints = points;
            this.foodColor = foodColor;
        }

        public int FoodPoints { get; private set; }

        public char FoodSymbol { get; private set; }

        public void SetRandomPosition(Queue<Point> snakePartsPosition)
        {
            this.LeftX = this.generator.Next(1, this.wall.LeftX - 1);
            this.TopY = this.generator.Next(1, this.wall.TopY - 1);

            // check if the position of our random points is equal to the snake’s position
            bool isWithinSnake = snakePartsPosition.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
            while (isWithinSnake)
            {
                this.LeftX = this.generator.Next(1, this.wall.LeftX - 1);
                this.TopY = this.generator.Next(1, this.wall.TopY - 1);

                isWithinSnake = snakePartsPosition.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
            }

            Console.BackgroundColor = this.foodColor;
            this.Draw(this.FoodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakePosition)
        {
            return snakePosition.LeftX == this.LeftX &&
                    snakePosition.TopY == this.TopY;
        }
    }
}
