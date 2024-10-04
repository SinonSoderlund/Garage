using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Car : Vehicle
    {
        public EEngineType EngineType { get; set; }

        public Car(EColors color, string registrationNumber, int numberOfWheels, EEngineType engineType) : base(color, registrationNumber, numberOfWheels)
        {
            EngineType = engineType;
        }
        public override string Print()
        {
            return $"{base.Print()}, Engine type: {EngineType}";
        }
        public override string Name()
        {
            return "Car";
        }
    }
}
