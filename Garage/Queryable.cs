using Garage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Queryable
    {
        private EColors? color;
        EOps? colorEopsLimited;
        private string? regNr;
        EOps? regOpsLimited;
        int? nrOFWheels;
        EOps? wheelsEops;
        EVehicleType? name;
        EOps? nameEOpsLimited;
        public Queryable() 
        {
            color = null;
            colorEopsLimited = null;
            regNr = null;
            regOpsLimited = null;
            nrOFWheels = null;
            wheelsEops = null;
            name = null;
            nameEOpsLimited = null;
        }

        public void Reset()
        {
            color = null;
            colorEopsLimited = null;
            regNr = null;
            regOpsLimited = null;
            nrOFWheels = null;
            wheelsEops = null;
            name = null;
            nameEOpsLimited = null;
        }

        public void SetQueryColor()
        {
            color = MenuHelper.GetColor();
            colorEopsLimited = MenuHelper.GetOpsLimitedType();
        }
        public string GetQueryColor ()
        {
            bool select = color != null;
            return $"{(select ? colorEopsLimited : "")}, {(select ? color : "")}";
        }
        public void SetQueryRegNr()
        {
            regNr = ConsoleUtils.GetInputString("Registration number", "Please input a valid registration number").ToUpper();
            regOpsLimited = MenuHelper.GetOpsLimitedType();
        }
        public string GetQueryRegNr()
        {
            bool select = regNr != null;
            return $"{(select ? regOpsLimited : "")}, {(select ? regNr : "")}";
        }
        public void SetQueryNrOfWheels()
        {
            nrOFWheels = ConsoleUtils.GetInputInt("Number of Wheels", "Please input a valid Number of wheels");
            wheelsEops = MenuHelper.GetOpsType();
        }
        public string GetQueryNrOfWheels()
        {
            bool select = nrOFWheels != null;
            return $"{(select ? wheelsEops : "")}, {(select ? nrOFWheels : "")}";
        }
        public void SetQueryName()
        {
            name = MenuHelper.GetVehicleType();
            nameEOpsLimited = MenuHelper.GetOpsLimitedType();
        }
        public string GetQueryName()
        {
            bool select = name != null;
            return $"{(select ? nameEOpsLimited : "")}, {(select ? name : "")}";
        }
        public void ExecuteQuery()
        {
        }
        

    }
}
