﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : 
            base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = this.FuelConsumption;
        }

        public override double FuelConsumption => 3.0;
    }
}
