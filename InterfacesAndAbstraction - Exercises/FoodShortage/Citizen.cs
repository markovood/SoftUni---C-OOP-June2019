using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IIdentifiable, IBirthable, IIdentifyableBuyer, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Food = 0;
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            this.Food += 10;
            return 10;
        }
    }
}
