namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            string objAsStr = (string)obj;
            return objAsStr.Trim().Length != 0;
        }
    }
}
