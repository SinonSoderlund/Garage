using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class GarageHandler : IHandler
    {
        private Garage<Vehicle> garage;


        /// <summary>
        /// Checks the capacity of the garage array, and returns it state.
        /// </summary>
        /// <returns>enum, either full, spare, or empty.</returns>
        public ECapacity capacity()
        {
            var state = garage.GetState();
            if(state.Item1 < 1)
                return ECapacity.empty;
            else if(state.Item1 == state.Item2-1)
                return ECapacity.full;
            else return ECapacity.spare;
        }

        public void CreateGarage(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
        }

        public List<string> DisplayVehicles()
        {
            if (garage.Count() == 0)
            {
                return null;
            }
            else
            {
                List<string> result = new List<string>();
                foreach (Vehicle v in garage)
                    result.Add($"{v.Print()}\n");
                return result;
            }
            
        }

        public string FindVehicle(string registrationNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetVehicles()
        {
            throw new NotImplementedException();
        }

        public bool HasGarage()
        {
            return garage != null;
        }

        public bool RemoveVehicle(string regNr)
        {
            return garage.FindAndRemove(regNr);
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            return garage.AddVehicle(vehicle);
        }
    }
}
