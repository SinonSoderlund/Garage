using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {

        private Vehicle[] vehicles;
        private int index;
        public Garage(int capacity)
        {
            vehicles = new Vehicle[capacity];
            index = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (Vehicle v in vehicles)
                if (v is T t) yield return t;
                else if (v == null)
                    yield break;
                else throw new ArrayTypeMismatchException($"{v} in array type of {nameof(T)} is not {nameof(T)}, this shoud never occur.");

        }
        /// <summary>
        /// Returns the index and leght of the vehicles array
        /// </summary>
        /// <returns></returns>
        public (int, int) GetState()
        {
            return (index,  vehicles.Length);
        }

        public bool AddVehicle(Vehicle Vehicle)
        {
            if(index <  vehicles.Length-1)
                vehicles[index++] = Vehicle;
            else 
                return false;
            return true;
        }
        public bool FindAndRemove(string regNr)
        {
            for (int i = 0; i < index; i++)
                if (vehicles[i].RegistrationNumber == regNr)
                {
                    if (i < index)
                        for (int j = i; j < index; j++)
                            vehicles[j] = vehicles[j + 1];
                    index--;
                    return true;
                }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return this.GetEnumerator();
        }

    }


}
