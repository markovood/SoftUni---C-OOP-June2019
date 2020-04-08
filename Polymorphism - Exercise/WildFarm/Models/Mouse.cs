using System;

using WildFarm.Models.Abstractions;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) :
            base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                base.Eat(food);
                this.Weight += 0.1 * food.Quantity;
            }
            else
            {
                throw new ArgumentException($"Mouse does not eat {food.GetType().Name}!");
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
