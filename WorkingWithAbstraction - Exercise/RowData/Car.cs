using System;
using System.Collections.Generic;
using System.Text;

namespace RowData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tiresSet)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.TiresSet = tiresSet;
        }

        public string Model { get; }

        public Engine Engine { get; }

        public Cargo Cargo { get; }

        public Tire[] TiresSet { get; }

        public override string ToString()
        {
            return this.Model;
        }
    }
}
