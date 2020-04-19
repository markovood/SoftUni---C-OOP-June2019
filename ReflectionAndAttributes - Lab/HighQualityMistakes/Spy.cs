using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HighQualityMistakes
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsNames)
        {
            StringBuilder result = new StringBuilder();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == classToInvestigate);
            if (type != null)
            {
                List<FieldInfo> searchedFields = new List<FieldInfo>();
                foreach (var fieldName in fieldsNames)
                {
                    FieldInfo field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    if (field != null)
                    {
                        searchedFields.Add(field);
                    }
                }

                result.AppendLine($"Class under investigation: {type.Name}");

                object instance = Activator.CreateInstance(type);

                foreach (var field in searchedFields)
                {
                    result.AppendLine($"{field.Name} = {field.GetValue(instance)}");
                }
            }

            return result.ToString().Trim();
        }

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
