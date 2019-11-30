using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, KeyValuePair<double, int>[] tiresSet)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.TiresSet = tiresSet;
        }

        public string Model { get; }
        public Engine Engine { get; }
        public Cargo Cargo { get; }
        public KeyValuePair<double, int>[] TiresSet { get; }
    }
}
