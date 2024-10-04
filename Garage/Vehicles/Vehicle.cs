using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Vehicle : IVehicle
    {
        public EColors Color { get; set; }
        public string RegistrationNumber { get; set; }
        public int NumberOfWheels { get; set; }


        public Vehicle(EColors color, string registrationNumber, int numberOfWheels)
        {
            Color = color;
            RegistrationNumber = registrationNumber.ToUpper();
            NumberOfWheels = numberOfWheels;
        }
        /// <summary>
        /// Prints the vehicle data
        /// </summary>
        /// <returns></returns>
        public virtual string Print()
        {
            return $"Type: {Name()}, Color: {Color}, Registration Number: {RegistrationNumber}, Number of wheels: {NumberOfWheels}";
        }

        /// <summary>
        /// Returns string of vehicle type name
        /// </summary>
        /// <returns></returns>
        public virtual string Name()
        {
            return "Vehicle";
        }
    }
}
