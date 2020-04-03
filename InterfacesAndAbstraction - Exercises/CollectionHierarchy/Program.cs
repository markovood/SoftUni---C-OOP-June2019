using System;
using System.Collections.Generic;

using CollectionHierarchy.Models;

namespace CollectionHierarchy
{
    public class Program
    {
        public static void Main()
        {
            var addCollection = new AddCollection<string>();
            var addRemoveCollection = new AddRemoveCollection<string>();
            var myList = new MyList<string>();

            string[] strs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var acOps = new List<int>();
            var arcOps = new List<int>();
            var mlOps = new List<int>();
            foreach (var str in strs)
            {
                acOps.Add(addCollection.Add(str));
                arcOps.Add(addRemoveCollection.Add(str));
                mlOps.Add(myList.Add(str));
            }

            Console.WriteLine(Concatenate(acOps));
            Console.WriteLine(Concatenate(arcOps));
            Console.WriteLine(Concatenate(mlOps));

            int removeOperationsCount = int.Parse(Console.ReadLine());

            string[] arcRemoved = new string[removeOperationsCount];
            string[] mlRemoved = new string[removeOperationsCount];
            for (int i = 0; i < removeOperationsCount; i++)
            {
                arcRemoved[i] = addRemoveCollection.Remove();
                mlRemoved[i] = myList.Remove();
            }

            Console.WriteLine(Concatenate(arcRemoved));
            Console.WriteLine(Concatenate(mlRemoved));
        }

        private static string Concatenate<T>(IEnumerable<T> collection)
        {
            return string.Join(' ', collection);
        }
    }
}
