using System;

using CustomTestingFramework.TestRunner;

namespace MyProgram
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var runner = new TestRunner();

            var result = runner.Run(@"..\..\..\..\CustomTestingFramework.Tests\bin\Debug\netcoreapp2.1\CustomTestingFramework.Tests.dll");

            //foreach (var info in result)
            //{
            //    Console.WriteLine(info);
            //}

            var itemResult = runner.Run(@"..\..\..\..\Demo.Tests\bin\Debug\netcoreapp2.1\Demo.Tests.dll");

            foreach (var info in itemResult)
            {
                Console.WriteLine(info);
            }
        }
    }
}
