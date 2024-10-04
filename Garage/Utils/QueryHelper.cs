using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Utils
{
    internal class QueryHelper
    {
        /// <summary>
        /// Performs the Color query on the passsed list
        /// </summary>
        /// <param name="vehicles">Ref list of vehicles on which the query is to take place, changes list contents</param>
        /// <param name="eColor">Color parameter to be used</param>
        /// <param name="ops">Limited ops</param>
        /// <returns>The list containing only those vehicles that fulfill query criteria.</returns>
        public static List<Vehicle> ColorPicker(ref List<Vehicle> vehicles, EColors eColor, EOpsLimited ops)
        {
            if (ops == EOpsLimited.Equal)
                return vehicles = vehicles.Where(v => v.Color == eColor).ToList();
            else
                return vehicles = vehicles.Where(v => v.Color != eColor).ToList();
        }
        /// <summary>
        /// Performs the vehicle registration number query operations
        /// </summary>
        /// <param name="vehicles">ref to list of vehicles that the queery operation will take place on, changes list contents</param>
        /// <param name="regNr">string containing the registration number.</param>
        /// <param name="ops">Limited ops comparison parameter</param>
        /// <returns>The list containing only those vehicles that fulfill query criteria.</returns>
        public static List<Vehicle> RegistrationPicker(ref List<Vehicle> vehicles, string regNr, EOpsLimited ops)
        {
            if (ops == EOpsLimited.Equal)
                return vehicles = vehicles.Where(v => v.RegistrationNumber == regNr).ToList();
            else
                return vehicles = vehicles.Where(v => v.RegistrationNumber != regNr).ToList();
        }
        /// <summary>
        /// Performs the vehicle wheel number query operations
        /// </summary>
        /// <param name="vehicles">ref to list of vehicles that the queery operation will take place on, changes list contents</param>
        /// <param name="NrOfWheels">The number of wheels along which queery operations will take place</param>
        /// <param name="ops">EOps comparison parameter.</param>
        /// <returns>The list containing only those vehicles that fulfill query criteria.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<Vehicle> WheelPicker(ref List<Vehicle> vehicles, int NrOfWheels, EOps ops)
        {
            switch (ops)
            {
                case EOps.Equal:
                    return vehicles = vehicles.Where(v => v.NumberOfWheels == NrOfWheels).ToList();
                case EOps.NotEqual:
                    return vehicles = vehicles.Where(v => v.NumberOfWheels != NrOfWheels).ToList();
                case EOps.GreaterThan:
                    return vehicles = vehicles.Where(v => v.NumberOfWheels > NrOfWheels).ToList();
                case EOps.GreaterThanOrEqual:
                    return vehicles = vehicles.Where(v => v.NumberOfWheels >= NrOfWheels).ToList();
                case EOps.LessThan:
                    return vehicles = vehicles.Where(v => v.NumberOfWheels < NrOfWheels).ToList();
                case EOps.LessThanOrEqual:
                    return vehicles = vehicles.Where(v => v.NumberOfWheels <= NrOfWheels).ToList();
                default:
                    throw new ArgumentException("Ops was passed with an invalid value, shoud never occcur");
            }
        }
        /// <summary>
        /// Performs the vehicle type query operations
        /// </summary>
        /// <param name="vehicles">ref to list of vehicles that the queery operation will take place on, changes list contents</param>
        /// <param name="type">The vehicle type argument.</param>
        /// <param name="ops">Limited ops comparison parameter</param>
        /// <returns>The list containing only those vehicles that fulfill query criteria.</returns>
        public static List<Vehicle> TypePicker(ref List<Vehicle> vehicles, EVehicleType type, EOpsLimited ops)
        {
            if (ops == EOpsLimited.Equal)
                return vehicles = vehicles.Where(v => v.Name() == type.ToString()).ToList();
            else
                return vehicles = vehicles.Where(v => v.Name() != type.ToString()).ToList();
        }

    }
}
