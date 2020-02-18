using System;

namespace Farm
{
    public class StartUp
    {
        const string SEPARATOR = "**********";

        public static void Main()
        {
            // Problem 1: Single inheritance
            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();
            Console.WriteLine(SEPARATOR);

            // Problem 2: Multiple inheritance
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
            Console.WriteLine(SEPARATOR);

            // Problem 3: Hierarchical inheritance
            Dog otherDog = new Dog();
            otherDog.Eat();
            otherDog.Bark();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}
