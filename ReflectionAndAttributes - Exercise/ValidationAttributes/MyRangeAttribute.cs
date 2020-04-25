namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            int objAsInt = (int)obj;
            if (objAsInt < this.minValue || objAsInt > this.maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
