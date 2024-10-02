using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal interface IHandler
    {

        void CreateGarage(int capacity);
        bool AddVehicle(Vehicle vehicle);
        bool RemoveVehicle(string regNr);
        string FindVehicle(string registrationNumber);
        List<string> DisplayVehicles();
        IEnumerable<string> GetVehicles();
        public bool HasGarage();
        public ECapacity capacity();



    }
}
