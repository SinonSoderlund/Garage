using Garage.UI;
using Garage.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class UserInterface : IUI
    {
        private MenuContexts UImenuContexts;
        private MenuContext UImenuContext;
        private IHandler? UIgarageHandler;
        private Queryable UIqueryObject;
        public UserInterface()
        {
            UImenuContext = null!;
            UImenuContexts = null!;
            UImenuContext = null!;
            UIqueryObject = null!;
        }



        /// <summary>
        /// Gather input and invokes the current menu context, if an invalid input was given then clears console, requests valid input and redisplays current menu.
        /// </summary>
        /// <param name="menuContext">the current menu context</param>
        public void ActOnInput()
        {
            while (true)
                if (!UImenuContext.ActOnInput(ConsoleUtils.GetInputInt("Menu option.", "Please choose an option.")))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid menu option\n");
                    DisplayOptions();
                }
                else
                    break;
        }

        /// <summary>
        /// Main function for the vehicle adding and removal functionality
        /// </summary>
        public void AddOrRemoveVehicle()
        {
            ECapacity capacity = UIgarageHandler!.capacity();
            if (capacity != ECapacity.empty)
                ViewAllVehicles();
            MenuHelper.DisplayAddRemoveOptions(capacity);

            bool go = true;
            while (go)
            {
                switch (ConsoleUtils.GetInputString("Menu Option", "")![0])
                {
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                    case '+':
                        if (capacity == ECapacity.full)
                        {
                            Console.WriteLine("Adding vehicles is not possible");
                            break;
                        }
                        UIgarageHandler.AddVehicle(MenuHelper.CreateAVehicle());
                        go = false;
                        break;
                    case '-':
                        if (capacity == ECapacity.empty)
                        {
                            Console.WriteLine("Removing vehicles is not possible");
                            break;
                        }
                        MenuHelper.RemoveAVehicle(UIgarageHandler);
                        go = false;
                        break;
                }
            }
            Console.WriteLine("Vehicle operation enacted sucessfully");


        }
        /// <summary>
        /// Creates garage
        /// </summary>
        public void CreateGarage()
        {
            UIgarageHandler!.CreateGarage(ConsoleUtils.GetInputString("Garage name", "Please input a valid garage name"),
                ConsoleUtils.GetRangeCheckedInputInt("Garage size", "Please input a valid garage size.", 1, int.MaxValue),
                ConsoleUtils.GetRangeCheckedInputInt("Answer", "Do you want to have the garage prepopulated? (4 vehicles for every 5 spaces up to 15 spaces, press 1 for yes, 0 for no)", 0, 1).ToBool());
            Console.WriteLine("Garage sucessfully created");
        }

        /// <summary>
        /// Prints the menu context display string.
        /// </summary>
        /// <param name="menuContext">the current menu context</param>
        public void DisplayOptions()
        {
            Console.WriteLine(UImenuContext.GetDisplayString());
        }

        /// <summary>
        /// Opens the queryable menu context, purges previous query data
        /// </summary>
        public void FindVehicle()
        {
            UIqueryObject.Reset();
            UImenuContext = UImenuContexts.QueryMenu;
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        public void Quit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// The ui loop, starts by assinging UI variables, then enters loop, clears console, prints menu, takes input, and waits for confirmation to continue after menu option execution,
        /// </summary>
        /// <param name="menuContexts">The Menu contexts item, contains the program menus.</param>
        /// <param name="menuContext">The current menu context.</param>
        /// <param name="garageHandler">The program Ihandler.</param>
        /// <param name="queryObject">The program query object.</param>
        public void RunUI(MenuContexts menuContexts, MenuContext menuContext, IHandler garageHandler, Queryable queryObject)
        {
            UImenuContexts = menuContexts;
            UImenuContext = menuContext;
            UIgarageHandler = garageHandler;
            UIqueryObject = queryObject;
            while (true)
            {
                Console.Clear();
                DisplayOptions();
                ActOnInput();
                ConsoleUtils.WaitToContinue();
            }
        }

        /// <summary>
        /// Prints out the vehicles by vehicle type function return
        /// </summary>
        public void VehicleTypes()
        {
            List<string> strings = UIgarageHandler!.GetVehicles();
            if (strings != null)
                foreach (string v in strings)
                    Console.WriteLine(v);
            else
                Console.WriteLine("Garage is empty, please add some vehicles to the garage before trying again");
        }

        /// <summary>
        /// Prints out the list of strings returned by garage handler
        /// </summary>
        public void ViewAllVehicles()
        {
            List<string> list = UIgarageHandler!.DisplayVehicles();
            if (list != null)
                foreach (string v in list)
                    Console.WriteLine(v);
            else Console.WriteLine("Garage is empty, please add some vehicles to the garage before trying again");
        }

        /// <summary>
        /// Changes current context to garage mangement if there is a garage, if not user is istructed to create one
        /// </summary>
        public void ManageGarage()
        {
            if (UIgarageHandler!.HasGarage())
                UImenuContext = UImenuContexts.ManageGarageMenu;
            else
                Console.WriteLine("No garage available, please create a new one before trying to manage it.");
        }

        /// <summary>
        /// Changes current context to main menu
        /// </summary>
        public void ReturnToMain()
        {
            UImenuContext = UImenuContexts.MainMenu;
        }

        /// <summary>
        /// Changes current context to garage management menu
        /// </summary>
        public void ReturnToGarageMenu()
        {
            UImenuContext = UImenuContexts.ManageGarageMenu;
        }
        /// <summary>
        /// Presents user with the list of garages, and askes them to pick one to delete, unless there are no garages
        /// </summary>
        public void RemoveGarage()
        {
            var garagesInfo = UIgarageHandler!.PrintGarages();
            Console.WriteLine(garagesInfo.Item2);
            //If garage was empty, exit function
            if (!garagesInfo.Item1)
                return;
            while (true)
                if (UIgarageHandler.DeleteGarage(ConsoleUtils.GetInputString("Garage name", "Please input the name of the garage you wish to remove")))
                    break;
                else
                    Console.WriteLine("No garage by that name found, please enter the name of an existing garage.");

        }
        /// <summary>
        /// Presents user with the list of garages, and askes them to pick one to manage, unless there are no garages
        /// </summary>
        public void ChangeGarage()
        {
            var garagesInfo = UIgarageHandler!.PrintGarages();
            Console.WriteLine(garagesInfo.Item2);
            //If garage was empty, exit function
            if (!garagesInfo.Item1)
                return;
            while (true)
                if (UIgarageHandler.ChangeGarage(ConsoleUtils.GetInputString("Garage name", "Please input the name of the garage you wish to manage")))
                    break;
                else
                    Console.WriteLine("No garage by that name found, please enter the name of an existing garage.");
        }
        /// <summary>
        /// Prints the list of all garages.
        /// </summary>
        public void ShowGarages()
        {
            var garagesInfo = UIgarageHandler!.PrintGarages();
            Console.WriteLine(garagesInfo.Item2);
        }

        /// <summary>
        /// Return the current garage data if current garage is not null
        /// </summary>
        /// <returns></returns>
        public string CurrentGarage()
        {
            return UIgarageHandler!.CurrentGarage();
        }
    }
}
