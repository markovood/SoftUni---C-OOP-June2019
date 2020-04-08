using System;
using System.Collections.Generic;
using WildFarm.Models;
using WildFarm.Models.Abstractions;

namespace WildFarm
{
    public class Program
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();
            List<Food> foods = new List<Food>();

            int lineCounter = -1;
            while (true)
            {
                lineCounter++;//N.B. += 1
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (cmdArgs[0])
                {
                    case "Owl":
                        var owl = new Owl(cmdArgs[1], double.Parse(cmdArgs[2]), double.Parse(cmdArgs[3]));
                        animals.Add(owl);
                        break;
                    case "Hen":
                        var hen = new Hen(cmdArgs[1], double.Parse(cmdArgs[2]), double.Parse(cmdArgs[3]));
                        animals.Add(hen);
                        break;
                    case "Mouse":
                        var mouse = new Mouse(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3]);
                        animals.Add(mouse);
                        break;
                    case "Dog":
                        var dog = new Dog(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3]);
                        animals.Add(dog);
                        break;
                    case "Cat":
                        var cat = new Cat(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]);
                        animals.Add(cat);
                        break;
                    case "Tiger":
                        var tiger = new Tiger(cmdArgs[1], double.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]);
                        animals.Add(tiger);
                        break;
                    case "Vegetable":
                        var vegetable = new Vegetable(int.Parse(cmdArgs[1]));
                        foods.Add(vegetable);
                        break;
                    case "Fruit":
                        var fruit = new Fruit(int.Parse(cmdArgs[1]));
                        foods.Add(fruit);
                        break;
                    case "Meat":
                        var meat = new Meat(int.Parse(cmdArgs[1]));
                        foods.Add(meat);
                        break;
                    case "Seeds":
                        var seeds = new Seeds(int.Parse(cmdArgs[1]));
                        foods.Add(seeds);
                        break;
                }
            }

            for (int i = 0; i < animals.Count; i++)
            {
                try
                {
                    Console.WriteLine(animals[i].AskForFood());
                    animals[i].Eat(foods[i]);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            animals.ForEach(Console.WriteLine);
        }
    }
}
