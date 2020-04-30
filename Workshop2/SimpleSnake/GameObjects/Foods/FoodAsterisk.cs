using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char FOOD_SYMBOL = '*';
        private const int FOOD_POINTS = 1;

        public FoodAsterisk(Wall wall, ConsoleColor foodColor = ConsoleColor.White) :
            base(wall, FOOD_SYMBOL, FOOD_POINTS, foodColor)
        {
        }
    }
}
