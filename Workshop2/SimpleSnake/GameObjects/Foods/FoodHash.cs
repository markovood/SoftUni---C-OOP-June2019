using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char FOOD_SYMBOL = '#';
        private const int FOOD_POINTS = 3;

        public FoodHash(Wall wall, ConsoleColor foodColor = ConsoleColor.White) :
            base(wall, FOOD_SYMBOL, FOOD_POINTS, foodColor)
        {
        }
    }
}
