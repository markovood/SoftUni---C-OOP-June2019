using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        private const string MODEL = "488-Spider";

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver { get; private set; }

        public string Model => MODEL;

        public string PushBreaks()
        {
            return "Brakes!";
        }

        public string PushGas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{PushBreaks()}/{PushGas()}/{this.Driver}";
        }
    }
}
