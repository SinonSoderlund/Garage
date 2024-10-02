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

        public static string DisplayColors()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Pick a color:\n");
            foreach (EColors color in Enum.GetValues(typeof(EColors)))
                sb.Append($"{((int)color)}: {color}.\n");
            return sb.ToString();
        }
        public static string DisplayVehicleTypes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Pick a vehlice type:\n");
            foreach (EVehicleType type in Enum.GetValues(typeof(EVehicleType)))
                sb.Append($"{((int)type)}: {type}.\n");
            return sb.ToString();
        }
        public static string DisplayEngineTypes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Pick an engine type:\n");
            foreach (EEngineType type in Enum.GetValues(typeof(EEngineType)))
                sb.Append($"{((int)type)}: {type}.\n");
            return sb.ToString();
        }
    }


}
