using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IIdentifyableBuyer, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Food = 0;
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public int Food { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int BuyFood()
        {
            this.Food += 5;
            return 5;
        }
    }
}
