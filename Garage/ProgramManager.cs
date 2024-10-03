using Garage.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class ProgramManager
    {
        private IHandler garageHandler;
        private IUI userInterface;
        private MenuContexts menuContexts;
        private Queryable queryObject;
        public ProgramManager()
        {
            garageHandler = new GarageHandler();
            userInterface = new UserInterface();
            queryObject = new Queryable();
            menuContexts = new MenuContexts(userInterface, queryObject);
        }
        public void Run()
        {
            while (true)
            userInterface.RunUI(menuContexts,menuContexts.MainMenu, garageHandler, queryObject);
        }
    }
}
