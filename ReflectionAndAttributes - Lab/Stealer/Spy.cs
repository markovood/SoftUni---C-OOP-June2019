using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
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
    }
}
