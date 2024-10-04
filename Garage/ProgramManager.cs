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
        //Should menu contexts, menu context and queryable be handled via interfaces? perhaps, but i dont feel like refactoring them
        //Also they are the core of the concrete implementation of the program so i feel like its defenseble
        private IHandler garageHandler;
        private IUI userInterface;
        private MenuContexts menuContexts;
        private Queryable queryObject;
        public ProgramManager()
        {
            garageHandler = new GarageHandler();
            userInterface = new UserInterface();
            queryObject = new Queryable(garageHandler);
            menuContexts = new MenuContexts(userInterface, queryObject);
        }
        public void Run()
        {
            while (true)
                userInterface.RunUI(menuContexts, menuContexts.MainMenu, garageHandler, queryObject);
        }
    }
}
