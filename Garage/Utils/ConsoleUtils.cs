using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal static class ConsoleUtils
    {
        /// <summary>
        /// Function to request and retreive desired string type data from a user via console
        /// </summary>
        /// <param name="RequestedItem">The type of input that is desired from the user, such as 'age'</param>
        /// <param name="FullPrompt">The full request, for example if age is requested then a suitable additionalPrompt me be 'please enter your age'</param>
        /// <param name="acceptBlank">Controlls if a blank or otherwise empty return string is accepted, default no</param>
        /// <returns>The validated console input</returns>
        public static string GetInputString(string RequestedItem, string FullPrompt, bool acceptBlank = false)
        {

                Console.WriteLine(FullPrompt);
            if (!acceptBlank)
                while (true)
                {
                    string input = Console.ReadLine()!;
                    if (!string.IsNullOrWhiteSpace(input))
                        return input;
                    else
                        ValidRequestor(RequestedItem);
                }
            else
                return Console.ReadLine()!;
        }
        /// <summary>
        ///  Runs GetInputString And then converts it into a valid int
        /// </summary>
        /// <param name="RequestedItem">The type of input that is desired from the user, such as 'age'</param>
        /// <param name="FullPrompt">The full request, for example if age is requested then a suitable additionalPrompt me be 'please enter your age'</param>
        /// <returns>A valid int value</returns>
        public static int GetInputInt(string RequestedItem, string FullPrompt)
        {
            while (true)
            {
                if (int.TryParse(GetInputString(RequestedItem, FullPrompt, false), out int input))
                {
                    return input;
                }
                else
                    ValidRequestor(RequestedItem);
            }
        }
        /// <summary>
        /// Range checked version of get int
        /// </summary>
        /// <param name="RequestedItem">The type of input that is desired from the user, such as 'age'</param>
        /// <param name="FullPrompt">The full request, for example if age is requested then a suitable additionalPrompt me be 'please enter your age'</param>
        /// <param name="min">minmum allowed value (inclusive).</param>
        /// <param name="max">maximum allowed value(inclusive).</param>
        /// <returns></returns>
        public static int GetRangeCheckedInputInt(string RequestedItem, string FullPrompt, int min, int max)
        {
            while (true)
            {
                int.TryParse(GetInputString(RequestedItem, FullPrompt, false), out int input);
                if (input <= max && input >= min)
                {
                    return input;
                }
                else
                {
                    bool select = input > max;
                    Console.WriteLine($"Please enter a valid number {(select ? "Lesser" : "Greater")} than or equal to {(select ? max : min)}");
                }

            }
        }
        /// <summary>
        /// Runs GetInputString And then converts it into a valid double
        /// </summary>
        /// <param name="RequestedItem">The type of input that is desired from the user, such as 'age'</param>
        /// <param name="FullPrompt">The full request, for example if age is requested then a suitable additionalPrompt me be 'please enter your age'</param>
        /// <returns>A valid double value</returns>
        public static Double GetInputDouble(string RequestedItem, string FullPrompt)
        {
            while (true)
            {
                if (Double.TryParse(GetInputString(RequestedItem, FullPrompt, false), out double input))
                {
                    return input;
                }
                else
                    ValidRequestor(RequestedItem);
            }
        }
        /// <summary>
        /// Function for querying the user for an answer, presenting a yes and no option and returning true or false based on answer
        /// </summary>
        /// <param name="RequestedInput">Generally just 'Answer'</param>
        /// <param name="returnTrueIfEqual">the value to be entered for yes</param>
        /// <param name="returnFalseIfEqual">the value to be entered for no</param>
        /// <param name="additionalPrompt">the actual question being asked, most often</param>
        /// <returns>true or false</returns>
        public static bool GetInputbool(string RequestedInput, string returnTrueIfEqual, string returnFalseIfEqual, string additionalPrompt = "")
        {
            while (true)
            {
                string input = GetInputString(RequestedInput, additionalPrompt, false);
                if (input == returnTrueIfEqual)
                    return true;
                else if (input == returnFalseIfEqual)
                    return false;
                else
                    ValidRequestor(RequestedInput);
            }
        }
        /// <summary>
        /// Function for getting an int without an initial prompt
        /// </summary>
        /// <param name="RequestedInput">the input that was requested, only displayed if the user inputs a non-int</param>
        /// <returns></returns>
        public static int GetIntSilent(string RequestedInput)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    return input;
                }
                else
                    ValidRequestor(RequestedInput);
            }
        }
        /// <summary>
        /// Short function that displays a request for the user to input a valid value
        /// </summary>
        /// <param name="RequestedInput">The type of input that is desired from the user</param>
        public static void ValidRequestor(string RequestedInput)
        {
            Console.WriteLine($"Please input a valid {RequestedInput}");
        }
        /// <summary>
        /// Asks user if they want to quit, returns true if they enter 1 
        /// </summary>
        /// <returns></returns>
        public static bool QuitProgramAsk()
        {
            if (GetInputString("Answer", "Do you want to quit the program? If no, input anything other than '1', else press 1 and enter your", true) == "1")
                return true;
            else return false;
        }

        /// <summary>
        /// Simple function to stall program until user presses enter
        /// </summary>
        public static void WaitToContinue()
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
