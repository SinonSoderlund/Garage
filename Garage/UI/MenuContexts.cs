using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    internal class MenuContexts
    {
        public MenuContext MainMenu { get; set; }
        public MenuContext ManageGarageMenu { get; set; }
        public MenuContexts(IUI userInterface) 
        { 
            MainMenu = new MenuContext("Main Menu",(1, "Create New Garage", userInterface.CreateGarage),(2, "Manage Garages", userInterface.ManageGarages), (0, "Quit", userInterface.Quit));
            ManageGarageMenu = new MenuContext("Garage Management", (1, "View Vehicle List", userInterface.ViewAllVehicles),
                (2, "Show vehicles by type", userInterface.VehicleTypes), (3, "Add or remove vehicle by registration number", userInterface.AddOrRemoveVehicle),
                (4, "Search for vehicles by properties", userInterface.FindVehicle), (0, "Return to main menu", userInterface.ReturnToMain));
        }

    }
}
