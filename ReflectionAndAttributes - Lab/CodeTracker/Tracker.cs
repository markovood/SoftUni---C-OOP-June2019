using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeTracker
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            // gets only methods that have AuthorAttribute from the specified type
            MethodInfo[] methods = type
                                    .GetMethods(BindingFlags.Instance |
                                                BindingFlags.Static |
                                                BindingFlags.Public |
                                                BindingFlags.NonPublic)
                                    .Where(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                                    .ToArray();

            // gets all AuthorAttributes for specified method and prints every attribute's author
            foreach (var method in methods)
            {
                IEnumerable<Attribute> attributes = method.GetCustomAttributes();
                Console.WriteLine($"{method.Name} is written by ");

                foreach (AuthorAttribute attr in attributes)
                {
                    Console.WriteLine($"  {attr.Name}");
                }
            }
        }
    }
}
