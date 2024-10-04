using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class MenuContext
    {
        public string Title { get; private set; }
        //Is this a good idea? eh. is it fun and convienient to use? Yeah kinda.
        private (int, (string, Func<string>?), Action)[] menuOption;
        /// <summary>
        /// Constructor for menu context
        /// </summary>
        /// <param name="title">Title of menu</param>
        /// <param name="options">The menu options, in form of a <int, <string, Func<string>>, Action> tripplet param array.
        /// The int is the option number for the menu entry, the string (+ func (optional)) is the entry description, and the delegate should point to a function corresponding to the desired action of the option.</param>
        public MenuContext(string title, params(int, (string, Func<string>?), Action)[] options)
        {
            Title = title;
            menuOption = options;
        }
    /// <summary>
    /// Returns a string composed of the Title and meny options numbers and descriptors of the menu context
    /// </summary>
    /// <returns>Presentable menu string</returns>
    public string GetDisplayString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{Title}.\n");
            foreach (var v in menuOption)
                stringBuilder.Append($"{v.Item1}: {v.Item2.Item1}{(v.Item2.Item2 != null ? v.Item2.Item2.Invoke() : "")}\n");
            return stringBuilder.ToString();
        }
        /// <summary>
        /// Looks to see if the input is valid, then executes input function if it is
        /// </summary>
        /// <param name="i">The menu option to be executed</param>
        /// <returns>Bool indicating if menu option was sucessfully found and executed or not.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public bool ActOnInput(int i)
        {

            var v = menuOption.FirstOrDefault(t => t.Item1 == i);
            if(v != default)
                    if (v.Item3 != null)
                        v.Item3();
                    else
                        throw new NullReferenceException($"Menu call pointer for {Title}, option nr. {v.Item1} was null, this should not occur.");
            else return false;
            return true;
        }
    }
}
