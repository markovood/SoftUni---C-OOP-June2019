using System.Collections.Generic;
using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    public class Program
    {
        public static void Main()
        {
            var employee = new Employee("Pesho");
            var manager = new Manager("Gosho", new List<string>() { "document1", "document2", "document3" });
            var mechanic = new Mechanic("bai Stamat", new string[] { "kleshti", "otverka", "chuk" });

            var printer = new DetailsPrinter(new List<IEmployee>() { employee, manager, mechanic });
            printer.PrintDetails();
        }
    }
}
