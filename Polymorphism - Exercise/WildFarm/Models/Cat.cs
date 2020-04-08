using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Abstractions;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) :
            base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                base.Eat(food);
                this.Weight += 0.3 * food.Quantity;
            }
            else
            {
                throw new ArgumentException($"Cat does not eat {food.GetType().Name}!");
            }
        }
    }
}
