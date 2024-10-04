using Garage.Utils;

namespace Garage
{
    class Queryable
    {
        private IHandler handler;
        private EColors? color;
        private EOpsLimited? colorEopsLimited;
        private string? regNr;
        private EOpsLimited? regOpsLimited;
        private int? nrOFWheels;
        private EOps? wheelsEops;
        private EVehicleType? vehicleType;
        private EOpsLimited? vehicleTypeEOpsLimited;
        private bool[] isSet = new bool[4];

        public Queryable(IHandler Qhandler)
        {
            handler = Qhandler;
            color = null;
            colorEopsLimited = null;
            regNr = null;
            regOpsLimited = null;
            nrOFWheels = null;
            wheelsEops = null;
            vehicleType = null;
            vehicleTypeEOpsLimited = null;
            for (int i = 0; i < isSet.Length; i++)
                isSet[i] = false;
        }

        /// <summary>
        /// Resets all per-query queryable data
        /// </summary>
        public void Reset()
        {
            color = null;
            colorEopsLimited = null;
            regNr = null;
            regOpsLimited = null;
            nrOFWheels = null;
            wheelsEops = null;
            vehicleType = null;
            vehicleTypeEOpsLimited = null;
            for (int i = 0; i < isSet.Length; i++)
                isSet[i] = false;
        }

        /// <summary>
        /// Sets the EColors query data
        /// </summary>
        public void SetQueryColor()
        {
            color = MenuHelper.GetColor();
            colorEopsLimited = MenuHelper.GetOpsLimitedType();
            isSet[0] = true;
        }

        /// <summary>
        /// Returns the EColors query data as a string
        /// </summary>
        /// <returns></returns>
        public string GetQueryColor()
        {
            bool select = color != null;
            return $"{(select ? colorEopsLimited : "")}, {(select ? color : "")}";
        }

        /// <summary>
        /// Sets the regNr query data
        /// </summary>
        public void SetQueryRegNr()
        {
            regNr = ConsoleUtils.GetInputString("Registration number", "Please input a valid registration number").ToUpper();
            regOpsLimited = MenuHelper.GetOpsLimitedType();
            isSet[1] = true;
        }

        /// <summary>
        /// Returns the regNr query data as a string
        /// </summary>
        /// <returns></returns>
        public string GetQueryRegNr()
        {
            bool select = regNr != null;
            return $"{(select ? regOpsLimited : "")}, {(select ? regNr : "")}";
        }

        /// <summary>
        /// Sets the nrOfWheels query data
        /// </summary>
        public void SetQueryNrOfWheels()
        {
            nrOFWheels = ConsoleUtils.GetInputInt("Number of Wheels", "Please input a valid Number of wheels");
            wheelsEops = MenuHelper.GetOpsType();
            isSet[2] = true;
        }

        /// <summary>
        /// Returns the nrOfWheels query data as a string
        /// </summary>
        /// <returns></returns>
        public string GetQueryNrOfWheels()
        {
            bool select = nrOFWheels != null;
            return $"{(select ? wheelsEops : "")}, {(select ? nrOFWheels : "")}";
        }

        /// <summary>
        /// Sets the EVehicleType query data
        /// </summary>
        public void SetQueryVehicleType()
        {
            vehicleType = MenuHelper.GetVehicleType();
            vehicleTypeEOpsLimited = MenuHelper.GetOpsLimitedType();
            isSet[3] = true;
        }

        /// <summary>
        /// Returns Vehicle type query data as a string
        /// </summary>
        /// <returns></returns>
        public string GetQueryName()
        {
            bool select = vehicleType != null;
            return $"{(select ? vehicleTypeEOpsLimited : "")}, {(select ? vehicleType : "")}";
        }

        /// <summary>
        /// Runs over isSet, first to see if there is a valid query, then to execute the input query, then prints out result list
        /// </summary>
        public void ExecuteQuery()
        {
            for (int i = 0; i < isSet.Length; i++)
                if (isSet[i] == true)
                    break;
                else if (i == 3 && isSet[3] == false)
                {
                    Console.WriteLine("No Query Data set, please enter at least one query condition before executing query.");
                    return;
                }
            List<Vehicle> list = handler.GetList();
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("No vehicles in garage, please exit query menu and add some cars before trying to perform query operations.");
                return;
            }
            if (isSet[0])
                QueryHelper.ColorPicker(ref list!, color!.Value, colorEopsLimited!.Value);
            if (isSet[1])
                QueryHelper.RegistrationPicker(ref list!, regNr!, colorEopsLimited!.Value);
            if (isSet[2])
                QueryHelper.WheelPicker(ref list!, nrOFWheels!.Value, wheelsEops!.Value);
            if (isSet[3])
                QueryHelper.TypePicker(ref list!, vehicleType!.Value, vehicleTypeEOpsLimited!.Value);

            foreach (Vehicle vehicle in list)
                Console.WriteLine(vehicle.Print());

        }


    }
}
