using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var prop in properties)
            {
                MyValidationAttribute[] attributes = prop.GetCustomAttributes<MyValidationAttribute>().ToArray();
                foreach (var attr in attributes)
                {
                    if (!attr.IsValid(prop.GetValue(obj)))
                    {

                        return false;
                    }
                }
            }

            return true;
        }
    }
}
