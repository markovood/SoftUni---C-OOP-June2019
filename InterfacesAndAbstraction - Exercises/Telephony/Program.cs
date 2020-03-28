using System;
using System.Linq;

namespace Telephony
{
    public class Program
    {
        public static void Main()
        {
            var phone = new Smartphone();
            Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                ToList().
                ForEach(num => phone.Call(num));

            Console.ReadLine().
                Split(' ', StringSplitOptions.RemoveEmptyEntries).
                ToList().
                ForEach(site => phone.Browse(site));
        }
    }
}
