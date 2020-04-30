using System;
using System.Collections.Generic;
using System.Linq;

using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char SNAKE_SYMBOL = '\u25A0';
        private const char EMPTY_SPACE = ' ';

        private Wall wall;
        private Queue<Point> snakeElements;
        private List<Food> foods;
        private int nextLeftX;
        private int nextTopY;

        private int currentFoodIndex;

        public Snake(Wall wall)
        {
            this.snakeElements = new Queue<Point>();
            this.foods = new List<Food>();
            this.wall = wall;

            this.CreateSnake();
            this.GetFoods();

            this.currentFoodIndex = this.RandomFoodIndexToDisplay;
            this.foods[this.currentFoodIndex].SetRandomPosition(this.snakeElements);
        }

        public int Size => this.snakeElements.Count;

        private int RandomFoodIndexToDisplay => new Random().Next(0, this.foods.Count);

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();

            this.GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements.Any(p => p.LeftX == this.nextLeftX && p.TopY == this.nextTopY);
            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);
            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SNAKE_SYMBOL);

            if (this.foods[this.currentFoodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(EMPTY_SPACE);

            return true;
        }

        private void CreateSnake()
        {
            for (int i = 1; i <= 6; i++)
            {
                this.snakeElements.Enqueue(new Point(1, i));
            }
        }

        private void GetFoods()
        {
            this.foods.Add(new FoodAsterisk(this.wall, ConsoleColor.Red));
            this.foods.Add(new FoodDollar(this.wall, ConsoleColor.Green));
            this.foods.Add(new FoodHash(this.wall, ConsoleColor.Cyan));
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = this.foods[this.currentFoodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPoint(direction, currentSnakeHead);
            }

            this.currentFoodIndex = this.RandomFoodIndexToDisplay;
            this.foods[this.currentFoodIndex].SetRandomPosition(this.snakeElements);
        }
    }
}
