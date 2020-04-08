using System;

using WildFarm.Models.Abstractions;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) :
            base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                base.Eat(food);
                this.Weight += 0.4 * food.Quantity;
            }
            else
            {
                throw new ArgumentException($"Dog does not eat {food.GetType().Name}!");
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
