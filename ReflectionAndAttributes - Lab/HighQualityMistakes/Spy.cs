using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HighQualityMistakes
{
    public class Spy
    {
        public string AnalyzeAcessModifiers(string className)
        {
            Type typeToAnalyze = Assembly
                .GetExecutingAssembly()
                .DefinedTypes
                .FirstOrDefault(t => t.Name == className);

            StringBuilder result = new StringBuilder();
            if (typeToAnalyze != null)
            {
                FieldInfo[] wrongFields = typeToAnalyze.GetFields(BindingFlags.Instance | BindingFlags.Public);
                foreach (var field in wrongFields)
                {
                    result.AppendLine($"{field.Name} must be private!");
                }

                MethodInfo[] wrongGetters = typeToAnalyze
                    .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(m => m.Name.StartsWith("get_"))
                    .ToArray();
                foreach (var method in wrongGetters)
                {
                    result.AppendLine($"{method.Name} have to be public!");
                }

                MethodInfo[] wrongSetters = typeToAnalyze
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Where(m => m.Name.StartsWith("set_"))
                    .ToArray();
                foreach (var method in wrongSetters)
                {
                    result.AppendLine($"{method.Name} have to be private!");
                }
            }

            return result.ToString().Trim();
        }
    }
}
