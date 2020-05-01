using System;
using System.Text;
using System.Threading;

using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] pointsOfDirection;
        private Direction direction;
        private double sleepTime;
        private Snake snake;
        private Wall wall;

        public Engine(Wall wall, Snake snake)
        {
            this.pointsOfDirection = new Point[4];
            this.wall = wall;
            this.snake = snake;
            this.sleepTime = 100d;
        }

        public void Run()
        {
            this.CreateDirections();

            Console.SetCursorPosition(this.wall.LeftX + 15, 1);
            Console.WriteLine($"Statistics");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                PrintCurrentStatistics(this.snake);

                bool isMoving = this.snake.IsMoving(this.pointsOfDirection[(int)this.direction]);
                if (!isMoving)
                {
                    this.AskUserForRestart();
                }

                // this.sleepTime -= 0.01;
                Thread.Sleep((int)this.sleepTime);
            }
        }

        private void PrintCurrentStatistics(Snake snake)
        {
            Console.SetCursorPosition(this.wall.LeftX + 10, 7);
            Console.WriteLine($"Current score: {this.snake.Size - 6}");
        }

        private void CreateDirections()
        {
            this.pointsOfDirection[0] = new Point(1, 0); // down
            this.pointsOfDirection[1] = new Point(-1, 0); // up
            this.pointsOfDirection[2] = new Point(0, 1); // right
            this.pointsOfDirection[3] = new Point(0, -1); // left
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n: ");

            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                this.StopGame();
            }
        }

        private void StopGame()
        {
            const string END_GAME_MSG = "Game over!";

            Console.SetCursorPosition((this.wall.LeftX - END_GAME_MSG.Length) / 2, this.wall.TopY / 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(END_GAME_MSG);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
