using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class GarageHandler : IHandler
    {
        private List<Garage<Vehicle>>? garages = new List<Garage<Vehicle>>();
        private Garage<Vehicle>? garage;


        /// <summary>
        /// Checks the capacity of the garage array, and returns it state.
        /// </summary>
        /// <returns>enum, either full, spare, or empty.</returns>
        public ECapacity capacity()
        {
            var state = garage!.GetState();
            if (state.Item1 < 1)
                return ECapacity.empty;
            else if (state.Item1 == state.Item2)
                return ECapacity.full;
            else return ECapacity.spare;
        }
        /// <summary>
        /// Adds vehicles to the garage.
        /// </summary>
        private void Populate()
        {
            if (garage!.GetState().Item2 > 5)
            {
                garage.AddVehicle(new Car(EColors.purple, "A34652", 4, EEngineType.LNG));
                garage.AddVehicle(new Car(EColors.silver, "A35652", 4, EEngineType.LNG));
                garage.AddVehicle(new Bus(EColors.white, "A45444", 6, 50));
                garage.AddVehicle(new Motorcycle(EColors.black, "WROOOM", 2, 10));
            }
            if (garage!.GetState().Item2 > 10)
            {
                garage.AddVehicle(new Car(EColors.green, "A34653", 4, EEngineType.Petrol));
                garage.AddVehicle(new Car(EColors.silver, "A35654", 4, EEngineType.Diesel));
                garage.AddVehicle(new Bus(EColors.blue, "A44444", 4, 20));
                garage.AddVehicle(new Motorcycle(EColors.yellow, "M6565", 2, 5));
            }
            if (garage!.GetState().Item2 > 15)
            {
                garage.AddVehicle(new Car(EColors.purple, "A84652", 4, EEngineType.Petrol));
                garage.AddVehicle(new Car(EColors.gunmetal, "A55652", 4, EEngineType.LNG));
                garage.AddVehicle(new Bus(EColors.lime, "B65f4", 3, 4));
                garage.AddVehicle(new Vehicle(EColors.black, "MMM5", 7));
            }
        }

        /// <summary>
        /// Creates a new Garage of type Vehicle with the requested capacity
        /// </summary>
        /// <param name="capacity">The number of vehicles that can fit in the garage.</param>
        public void CreateGarage(string name, int capacity, bool prepopulate)
        {
            garage = new Garage<Vehicle>(capacity, name);
            garages!.Add(garage);
            if (prepopulate)
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

        /// <summary>
        /// Returns a list of all vehicles.
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> GetList()
        {
            return garage!.ToList();
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

        /// <summary>
        /// Searches for the garage and deletes it if it exists
        /// </summary>
        /// <param name="name">The garage to be deleted</param>
        /// <returns>True if operation suceeded, false if the garage was not found.<</returns>
        public bool DeleteGarage(string name)
        {
            if (garages!.Count == 0)
                return false;

            Garage<Vehicle> g = garages!.FirstOrDefault(g => g.Name() == name)!;
            if (g == default)
                return false;

            garages!.Remove(g);

            if (garages.Count != 0)
                garage = garages.FirstOrDefault();
            else
                garage = null;

            return true;
        }
        /// <summary>
        /// Changes the current garage to tne one supplied, unless there are no garages, or the specified garage does not exist
        /// </summary>
        /// <param name="name">Nameof the garage to be used.</param>
        /// <returns>True if operation succeds, else false</returns>
        public bool ChangeGarage(string name)
        {
            if (garages!.Count == 0)
                return false;

            Garage<Vehicle> g = garages!.FirstOrDefault(g => g.Name() == name)!;
            if (g == default)
                return false;

            garage = g;
            return true;
        }
        /// <summary>
        /// Prints out all garages, or a message informing the user that there are no garages if so is the case.
        /// </summary>
        /// <returns>Tuple, where the bool indicates if there are garages, and the string containing the garage data.</returns>
        public (bool,string) PrintGarages()
        {
            if (garages!.Count == 0)
                return (false, "There are no garages presently, please create one.");
            StringBuilder sb = new StringBuilder();
            sb.Append("The Garages:\n");
            foreach (Garage<Vehicle> g in garages)
                sb.Append($"{g.Print()}\n");
            return (true, sb.ToString());

        }
        /// <summary>
        /// Return the current garage unless garage is null, if so return empty string.
        /// </summary>
        /// <returns></returns>
        public string CurrentGarage()
        {
            return garage == null ? "" : $": {garage.Print()}";
        }
    }
}
