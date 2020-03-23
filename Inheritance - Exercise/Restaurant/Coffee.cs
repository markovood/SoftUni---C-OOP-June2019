using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public const double COFFEE_MILLILITERS = 50.0;

        public const decimal COFFEE_PRICE = 3.50m;

        public Coffee(string name, double caffeine) : 
            base(name, COFFEE_PRICE, COFFEE_MILLILITERS)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; }
    }
}
