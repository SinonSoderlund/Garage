using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Motorcycle : Vehicle
    {
        public double EngineCapcity { get; set; }

        public Motorcycle(EColors color, string registrationNumber, int numberOfWheels, double engineCapacity) : base(color, registrationNumber, numberOfWheels)
        {
            EngineCapcity = engineCapacity;
        }

        public override string Print()
        {
            return $"{base.Print()}, Engine capacity: {EngineCapcity}";
        }
        public override string Name()
        {
            return "Motorcycle";
        }
    }
}
