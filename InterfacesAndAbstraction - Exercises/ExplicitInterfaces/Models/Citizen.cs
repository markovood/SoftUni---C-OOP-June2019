using ExplicitInterfaces.Contracts;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        string IResident.GetName()
        {
            return "Mr/Ms/Mrs " + this.Name;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }
    }
}
