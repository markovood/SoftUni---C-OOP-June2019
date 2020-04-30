using System;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char FOOD_SYMBOL = '$';
        private const int FOOD_POINTS = 2;

        public FoodDollar(Wall wall, ConsoleColor foodColor = ConsoleColor.White) :
            base(wall, FOOD_SYMBOL, FOOD_POINTS, foodColor)
        {
        }
    }
}
