using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Abstractions;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) :
            base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                base.Eat(food);
                this.Weight += 1 * food.Quantity;
            }
            else
            {
                throw new ArgumentException($"Tiger does not eat {food.GetType().Name}!");
            }
        }
    }
}
