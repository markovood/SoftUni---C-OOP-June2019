using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        public const double GRAMS = 22.0;

        public Fish(string name, decimal price) :
            base(name, price, GRAMS)
        {
        }
    }
}
