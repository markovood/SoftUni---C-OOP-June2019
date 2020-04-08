using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Abstractions;

namespace WildFarm.Models
{
    public class Seeds : Food
    {
        public Seeds(int quantity) : 
            base(quantity)
        {
        }
    }
}
