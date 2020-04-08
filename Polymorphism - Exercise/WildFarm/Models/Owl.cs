using System;

using WildFarm.Models.Abstractions;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : 
            base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                base.Eat(food);
                this.Weight += 0.25 * food.Quantity;
            }
            else
            {
                throw new ArgumentException($"Owl does not eat {food.GetType().Name}!");
            }
        }
    }
}
