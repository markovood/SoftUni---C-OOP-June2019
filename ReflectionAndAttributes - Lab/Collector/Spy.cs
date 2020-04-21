using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Collector
{
    public class Spy
    {
        public string CollectGettersAndSetters(string className)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            StringBuilder result = new StringBuilder();

            Type type = assembly.DefinedTypes.FirstOrDefault(t => t.Name == className);
            if (type != null)
            {
                MethodInfo[] methods = type.GetMethods(BindingFlags.Instance |
                                                        BindingFlags.Static |
                                                        BindingFlags.NonPublic |
                                                        BindingFlags.Public);

                // MethodInfo[] getters = 
                methods
                    .Where(m => m.Name.StartsWith("get_"))
                    .ToList()
                    .ForEach(m => result.AppendLine($"{m.Name} will return {m.ReturnType}"));

                // MethodInfo[] setters = 
                methods
                    .Where(m => m.Name.StartsWith("set_"))
                    .ToList()
                    .ForEach(m => result.AppendLine($"{m.Name} will set field of {m.GetParameters().First().ParameterType}"));
            }

            return result.ToString().Trim();
        }
    }
}
