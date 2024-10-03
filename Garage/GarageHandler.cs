using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class GarageHandler : IHandler
    {
        private Garage<Vehicle>? garage;


        /// <summary>
        /// Checks the capacity of the garage array, and returns it state.
        /// </summary>
        /// <returns>enum, either full, spare, or empty.</returns>
        public ECapacity capacity()
        {
            var state = garage!.GetState();
            if(state.Item1 < 1)
                return ECapacity.empty;
            else if(state.Item1 == state.Item2)
                return ECapacity.full;
            else return ECapacity.spare;
        }

        private void Populate()
        {
            if(garage!.GetState().Item2 > 4)
            {
                garage.AddVehicle(new Car(EColors.purple, "A34652", 4, EEngineType.LNG));
                garage.AddVehicle(new Car(EColors.silver, "A35652", 4, EEngineType.LNG));
                garage.AddVehicle(new Bus(EColors.white, "A45444", 6, 50));
                garage.AddVehicle(new Motorcycle(EColors.black, "WROOOM", 2, 10));
            }
        }

        /// <summary>
        /// Creates a new Garage of type Vehicle with the requested capacity
        /// </summary>
        /// <param name="capacity">The number of vehicles that can fit in the garage.</param>
        public void CreateGarage(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
            Populate();
        }

        /// <summary>
        /// Returns all the vehicles in the garage, return null if there are none
        /// </summary>
        /// <returns>List<string> of vehicle data.</string></returns>
        public List<string> DisplayVehicles()
        {
            if (garage!.Count() == 0)
            {
                return null!;
            }
            else
            {
                List<string> result = new List<string>();
                foreach (Vehicle v in garage!)
                    result.Add($"{v.Print()}\n");
                return result;
            }
            
        }

        public string FindVehicle(string registrationNumber)
        {
            if (capacity() == ECapacity.empty)
                return null!;
            List<Vehicle> input = garage!.ToList();

            return "";
        }


        /// <summary>
        /// Gets the list of vehicles and groups them by their name, then collapses the grouping into a string.
        /// </summary>
        /// <returns>List of string holding vehicle types and their quantities.</returns>
        public List<string> GetVehicles()
        {
            if (capacity() == ECapacity.empty)
                return null!; 

            List<Vehicle> input = garage!.ToList();

            var v = input.GroupBy(veh => veh.Name()).ToList(); ;
            List<string> result = new List<string>();
            for (int i = 0; i < v.Count; i++)
                result.Add($"{v[i].Key}: {v[i].Count()}");
            return result;
        }

        /// <summary>
        /// Returns wether or not there is a garage.
        /// </summary>
        /// <returns></returns>
        public bool HasGarage()
        {
            return garage != null;
        }

        /// <summary>
        /// Calls FindandRemove on the harage using the regNr
        /// </summary>
        /// <param name="regNr">REgistration number of the vehicle that is to be removed</param>
        /// <returns>returns false if the sought after regNr wasnt in the list, true if remove operation was sucessfull.</returns>
        public bool RemoveVehicle(string regNr)
        {
            return garage!.FindAndRemove(regNr.ToUpper());
        }

        /// <summary>
        /// Calls addvehicle on the garage.
        /// </summary>
        /// <param name="vehicle">Vehicle to be added</param>
        /// <returns>returns false if operation failed, otherwise true.</returns>
        public bool AddVehicle(Vehicle vehicle)
        {
            return garage!.AddVehicle(vehicle);
        }
    }
}
