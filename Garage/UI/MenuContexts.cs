﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    internal class MenuContexts
    {
        public MenuContext MainMenu { get; private set; }
        public MenuContext ManageGarageMenu { get; private set; }
        public MenuContext QueryMenu { get; private set; }

        public MenuContexts(IUI userInterface, Queryable query) 
        { 
            MainMenu = new MenuContext("Main Menu",
                (1, ("Create New Garage",null), userInterface.CreateGarage),
                (2, ("Change managed Garage", null), userInterface.ChangeGarage),
                (3, ("Delete Garage", null), userInterface.RemoveGarage),
                (4, ("Show all Garages", null), userInterface.ShowGarages),
                (5, ("Manage Garage", userInterface.CurrentGarage), userInterface.ManageGarage), 
                (0, ("Quit", null), userInterface.Quit));

            ManageGarageMenu = new MenuContext("Garage Management",
                (1, ("View Vehicle List",null), userInterface.ViewAllVehicles),
                (2, ("Show vehicles by type", null), userInterface.VehicleTypes), 
                (3, ("Add or remove vehicle by registration number", null), userInterface.AddOrRemoveVehicle),
                (4, ("Search for vehicles by properties", null), userInterface.FindVehicle), 
                (0, ("Return to main menu", null), userInterface.ReturnToMain));
            
            //Should query meny actually be executed on UI functions? probably, if it were a real program id refactor it
            //but this isnt really a real program, so ill leave it be.
            QueryMenu = new MenuContext("Garage Query Menu\nEmpty Query fields will be ignored.",
                (1, ("Set Color Query: ", new Func<string>(() => query?.GetQueryColor()!)), query.SetQueryColor), 
                (2, ("Set Query Registration Number: ", new Func<string>(() => query?.GetQueryRegNr()!)), query.SetQueryRegNr), 
                (3, ("Set Query Number of Wheels:", new Func<string>(() => query?.GetQueryNrOfWheels()!)), query.SetQueryNrOfWheels),
                (4, ("Set Query Vehicle type: ", new Func<string>(() => query?.GetQueryName()!)), query.SetQueryVehicleType),
                (5, ("Executue Query", null), query.ExecuteQuery), 
                (0, ("Return to garage menu", null), userInterface.ReturnToGarageMenu));
        }

    }
}
