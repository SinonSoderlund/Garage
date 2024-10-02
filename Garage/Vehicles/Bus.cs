using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(EColors color, string registrationNumber, int numberOfWheels, int numberOfSeats) : base(color, registrationNumber, numberOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }
        public override string Print()
        {
            return $"{base.Print()}, Number of seats: {NumberOfSeats}";
        }
        public override string Name()
        {
            return "Bus";
        }
    }
}
