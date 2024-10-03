using Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal interface IUI
    {
        public void RunUI(MenuContexts menuContexts, MenuContext menuContext, IHandler garageHandler, Queryable queryObject);
        void DisplayOptions(MenuContext menuContext);
        void ActOnInput(MenuContext menuContext);
        void ManageGarages();
        void ViewAllVehicles();
        void VehicleTypes();
        void AddOrRemoveVehicle();
        void FindVehicle();
        void CreateGarage();
        void ReturnToMain();
        void Quit();
        void ReturnToGarageMenu();
    }
}
