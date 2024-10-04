using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {

        private Vehicle[] vehicles;
        private string name;
        private int index;

        /// <summary>
        /// Creates a new garage, sets garagae capacity to capacity, sets index to 0
        /// </summary>
        /// <param name="capacity">The number of vehicles to fit in the garage.</param>
        public Garage(int capacity, string name)
        {
            vehicles = new Vehicle[capacity];
            index = 0;
            this.name = name;
        }
        /// <summary>
        /// Prints out the garage instance data.
        /// </summary>
        /// <returns>String with garage name and capacity</returns>
        public string Print()
        {
            return $"Name: {name}, Capacity: {vehicles.Length}";
        }

        /// <summary>
        /// Returns just the garage name
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            return name;
        }
        /// <summary>
        /// runs a foreach over the vehicle array, casts elements to type t and returns them,, unless the list is empty.
        /// </summary>
        /// <returns>Ienumerator<T> of vehicle</T></returns>
        /// <exception cref="ArrayTypeMismatchException">throws in the case of a non-vehicle class in the vehicles array.</exception>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (Vehicle v in vehicles)
                if (v is T t) yield return t;
                else if (v == null)
                    yield break;
                else throw new ArrayTypeMismatchException($"{v} in array type of {nameof(T)} is not {nameof(T)}, this shoud never occur.");

        }

        /// <summary>
        /// Returns the index and lenght of the vehicles array
        /// </summary>
        /// <returns></returns>
        public (int, int) GetState()
        {
            return (index, vehicles.Length);
        }

        /// <summary>
        /// Adds the vehicle to the "head" of the list if there is space
        /// </summary>
        /// <param name="Vehicle">vehicle to be added.</param>
        /// <returns>True if adding vehicle is sucessfull, false if there is no more space</returns>
        public bool AddVehicle(Vehicle Vehicle)
        {
            if (index < vehicles.Length)
                vehicles[index++] = Vehicle;
            else
                return false;
            return true;
        }

        /// <summary>
        /// Searches the array for the sought after vehicle, if it exists, it is "removed", if it isnt the highest index item then all higher index items are moved one step back
        /// </summary>
        /// <param name="regNr">the registration number to be searched for</param>
        /// <returns>false if there is no such vehicle, true if removal is sucessfull.</returns>
        public bool FindAndRemove(string regNr)
        {
            for (int i = 0; i < index; i++)
                if (vehicles[i].RegistrationNumber == regNr)
                {
                    //If the index is OOB, pre-reduce it, set indexReduced to true so it doesnt get reduced at end of execution
                    bool indexReduced = false;
                    if (index == vehicles.Length)
                    {
                        --index;
                        indexReduced = true;
                    }
                    //if the vehicle to be removed isnt at index, backfill the array, then null index position
                    if (i < index)
                        for (int j = i; j + 1 <= index; j++)
                            vehicles[j] = vehicles[j + 1];
                    vehicles[index] = null!;
                    //if index wasnt already reduced, do so here
                    if (!indexReduced)
                        index--;
                    return true;
                }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this.GetEnumerator();
        }

        /// <summary>
        /// Returns a list of all the vehicles, the assigment specs do not forbid this.
        /// </summary>
        /// <returns>List of all vehicles</returns>
        public List<Vehicle> ToList()
        {
            List<Vehicle> list = new List<Vehicle>();
            foreach (Vehicle vehicle in vehicles)
                if (vehicle != null)
                    list.Add(vehicle);
            return list;
        }

    }


}
