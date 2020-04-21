using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MissionPrivateImpossible
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            StringBuilder result = new StringBuilder();

            Type type = assembly.DefinedTypes.FirstOrDefault(t => t.Name == className);
            if (type != null)
            {
                MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
                result.AppendLine($"All Private Methods of Class: {type.Name}")
                    .AppendLine($"Base Class: {type.BaseType.Name}");

                foreach (var method in privateMethods)
                {
                    result.AppendLine(method.Name);
                }
            }

            return result.ToString().Trim();
        }
    }
}
