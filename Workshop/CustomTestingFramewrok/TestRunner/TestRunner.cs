using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using CustomTestingFramework.Attributes;
using CustomTestingFramework.Exceptions;
using CustomTestingFramework.TestRunner.Contracts;
using CustomTestingFramework.Utilities;

namespace CustomTestingFramework.TestRunner
{
    public class TestRunner : ITestRunner
    {
        private readonly ICollection<string> resultInfo;

        public TestRunner()
        {
            this.resultInfo = new List<string>();
        }

        public ICollection<string> Run(string assemblyPath)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            var allclasses = assembly.GetTypes();
            var testClasses = allclasses
                                .Where(c => c.HasAttribute<TestClassAttribute>())
                                .ToList();

            foreach (var testClass in testClasses)
            {
                var testMethods = testClass
                                    .GetMethods(BindingFlags.Instance |
                                                BindingFlags.Public |
                                                BindingFlags.DeclaredOnly)
                                    .Where(m => m.HasAttribute<TestMethodAttribute>())
                                    .ToList();

                var testClassInstance = Activator.CreateInstance(testClass);
                foreach (var method in testMethods)
                {
                    try
                    {
                        method.Invoke(testClassInstance, null);
                        this.resultInfo.Add($"Method: {method.Name} - passed!");
                    }
                    catch (TargetInvocationException tie)
                    {
                        // System.Reflection wraps exceptions thrown during the invocation into TargetInvocationException so
                        if (tie.InnerException is TestException)
                        {
                            this.resultInfo.Add($"Method: {method.Name} - failed!");
                        }
                        else
                        {
                            this.resultInfo.Add($"Method: {method.Name} - Error '{tie.InnerException.Message}'!");
                        }
                    }
                    catch (Exception)
                    {
                        this.resultInfo.Add($"Method: {method.Name} - unexpected error occurred!");
                    }
                }
            }

            return this.resultInfo;
        }
    }
}
