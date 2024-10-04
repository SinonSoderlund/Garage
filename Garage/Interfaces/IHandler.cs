using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal interface IHandler
    {

        void CreateGarage(string name, int capacity, bool prepopulate);
        bool DeleteGarage(string name);
        bool ChangeGarage(string name);
        (bool, string) PrintGarages();
        string CurrentGarage();
        bool AddVehicle(Vehicle vehicle);
        bool RemoveVehicle(string regNr);
        List<string> DisplayVehicles();
        List<string> GetVehicles();
        public bool HasGarage();
        public ECapacity capacity();
        public List<Vehicle> GetList();


    }
}
