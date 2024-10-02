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

        public ProgramManager()
        {
            garageHandler = new GarageHandler();
            userInterface = new UserInterface();
            menuContexts = new MenuContexts(userInterface);
        }
        public void Run()
        {
            while (true)
            userInterface.RunUI(menuContexts,menuContexts.MainMenu, garageHandler);
        }
    }
}
