using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public const double GRAMS = 250.0;

        public const double CALORIES = 1000.0;

        public const decimal CAKE_PRICE = 5m;

        public Cake(string name) :
            base(name, CAKE_PRICE, GRAMS, CALORIES)
        {
        }
    }
}
