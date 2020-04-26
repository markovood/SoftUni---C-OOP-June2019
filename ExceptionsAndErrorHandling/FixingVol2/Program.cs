using System;

namespace FixingVol2
{
    public class Program
    {
        public static void Main()
        {
            int num1, num2;
            byte result;

            num1 = 30;
            num2 = 60;
            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Cannot write a value bigger than unsigned Int8 ");
            }
        }
    }
}
