using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Utils
{
    internal static class MenuHelper
    {
        /// <summary>
        /// Displays the appropriate text for wether or not vehicles can be added or removed
        /// </summary>
        /// <param name="capacity">Ecapacity aquired from the Ihandler.</param>
        public static void DisplayAddRemoveOptions(ECapacity capacity)
        {
            if (capacity == ECapacity.empty || capacity == ECapacity.spare)
                Console.WriteLine("Press + to add a vehicle");
            else Console.WriteLine("Garage full, not possible to add a vehicle at this moment.\nPress '-' to remove a vehicle.");
            if (capacity == ECapacity.spare)
                Console.WriteLine("Press '-' to remove a vehicle.");
            else if (capacity == ECapacity.empty)
                Console.WriteLine("Garage is empty, not possible to remove a vehicle at this time");
        }

        /// <summary>
        /// Promps the user to pick a color, the converts EColors to an array and prints out the values
        /// </summary>
        /// <returns>A string containing the data</returns>
        public static string DisplayColors()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Pick a color:\n");
            foreach (EColors color in Enum.GetValues(typeof(EColors)))
                sb.Append($"{((int)color)}: {color}.\n");
            return sb.ToString();
        }

        /// <summary>
        /// Promps the user to pick a vehicle type, the converts EVehicleType to an array and prints out the values
        /// </summary>
        /// <returns>A string containing the data</returns>
        public static string DisplayVehicleTypes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Pick a vehlice type:\n");
            foreach (EVehicleType type in Enum.GetValues(typeof(EVehicleType)))
                sb.Append($"{((int)type)}: {type}.\n");
            return sb.ToString();
        }

        /// <summary>
        /// Promps the user to pick an engine type, the converts EEngineType to an array and prints out the values
        /// </summary>
        /// <returns>A string containing the data</returns>
        public static string DisplayEngineTypes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Pick an engine type:\n");
            foreach (EEngineType type in Enum.GetValues(typeof(EEngineType)))
                sb.Append($"{((int)type)}: {type}.\n");
            return sb.ToString();
        }

        /// <summary>
        /// Promps the user to pick an ops type, the converts Eops to an array and prints out the values
        /// </summary>
        /// <returns>A string containing the data</returns>
        public static string DisplayEOpsTypes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Pick an engine type:\n");
            foreach (EOps type in Enum.GetValues(typeof(EOps)))
                sb.Append($"{((int)type)}: {type}.\n");
            return sb.ToString();
        }

        /// <summary>
        /// Promps the user to pick either equal or notequal ops type, the converts Eops to an array and prints out the values (very lazy solution)
        /// </summary>
        /// <returns>A string containing the data</returns>
        public static string DisplayEOpsLimitedTypes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Pick an engine type:\n");
            foreach (EOps type in Enum.GetValues(typeof(EOps)))
            {
                if (type == EOps.GreaterThan)
                    break;
                sb.Append($"{((int)type)}: {type}.\n");

            }
            return sb.ToString();
        }

        /// <summary>
        /// Prints out DisplayColors and then performs a rangechecked int console retreival which is casted to Ecolors
        /// </summary>
        /// <returns></returns>
        public static EColors GetColor()
        {
            Console.WriteLine(MenuHelper.DisplayColors());
            return (EColors)ConsoleUtils.GetRangeCheckedInputInt("Color", "Please input a valid color value", ((int)EColorRange.min), ((int)EColorRange.max));
        }

        /// <summary>
        /// Prints out DisplayVehicletypes and then performs a rangechecked int console retreival which is casted to EVehicleType
        /// </summary>
        /// <returns></returns>
        public static EVehicleType GetVehicleType()
        {
            Console.WriteLine(MenuHelper.DisplayVehicleTypes());
            return (EVehicleType)ConsoleUtils.GetRangeCheckedInputInt("Vehicle type", "Please input a valid vehicle type", ((int)EVehicleRange.min), ((int)EVehicleRange.max));
        }

        /// <summary>
        /// Prints out DisplayEngineTypes and then performs a rangechecked int console retreival which is casted to EEngineType
        /// </summary>
        /// <returns></returns>
        public static EEngineType GetEngineType()
        {
            Console.WriteLine(MenuHelper.DisplayEngineTypes());
            return (EEngineType)ConsoleUtils.GetRangeCheckedInputInt("Engine type", "Please input a valid engine type", ((int)EEngineRange.min), ((int)EEngineRange.max));
        }

        /// <summary>
        /// Prints out DisplayEOpsTypes and then performs a rangechecked int console retreival which is casted to EOps
        /// </summary>
        /// <returns></returns>
        public static EOps GetOpsType()
        {
            Console.WriteLine(MenuHelper.DisplayEOpsTypes());
            return (EOps)ConsoleUtils.GetRangeCheckedInputInt("Operation type", "Please input a valid Operation type", ((int)EOpsRange.min), ((int)EOpsRange.max));
        }

        /// <summary>
        /// Prints out DisplayEOpsLimitedTypes and then performs a rangechecked int console retreival which is casted to EOps (limited)
        /// </summary>
        /// <returns></returns>
        public static EOps GetOpsLimitedType()
        {
            Console.WriteLine(MenuHelper.DisplayEOpsLimitedTypes());
            return (EOps)ConsoleUtils.GetRangeCheckedInputInt("Operation type", "Please input a valid Operation type", ((int)EOpsRange.min), (1));
        }

        /// <summary>
        /// The console vehicle creation function
        /// </summary>
        /// <returns>A user specified vehicle.</returns>
        /// <exception cref="Exception">Should never occur.</exception>
        public static Vehicle CreateAVehicle()
        {
            EColors color = GetColor();
            string regNr = ConsoleUtils.GetInputString("Registration number", "Please input a registration number (any string of lenght > 0");
            int nrOfWheels = ConsoleUtils.GetInputInt("Number of wheels", "please input the number of wheels");
            EVehicleType type = GetVehicleType();
            switch (type)
            {
                case EVehicleType.Vehicle:
                    return new Vehicle(color, regNr, nrOfWheels);
                case EVehicleType.Car:
                    EEngineType eType = GetEngineType();
                    return new Car(color, regNr, nrOfWheels, eType);
                case EVehicleType.Bus:
                    int nrOfSeats = ConsoleUtils.GetInputInt("Number of Seats", "please input the number of seats");
                    return new Bus(color, regNr, nrOfWheels, nrOfSeats);
                case EVehicleType.Motorcycle:
                    double engineCapacity = ConsoleUtils.GetInputDouble("Engine capacity", "please input the engine capacity");
                    return new Motorcycle(color, regNr, nrOfWheels, engineCapacity);
                default:
                    throw new Exception("CreateAVehicle GetVehicleType Failed, this should never occur.");
            }
        }

        public static void RemoveAVehicle(IHandler handler)
        {
            Console.WriteLine("Please enter the registration number of the vehicle you wish to remove");
            while (true)
            {
                if (handler.RemoveVehicle(ConsoleUtils.GetInputString("Registartion number", "")))
                {
                    Console.WriteLine("Vehicle sucessfully removed");
                    return;
                }
                else
                    Console.WriteLine("Vehicle by that registration number was not found.");
            }
        }
    }

}
