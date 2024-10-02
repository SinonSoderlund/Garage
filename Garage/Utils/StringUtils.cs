using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal static class StringUtils
    {
        /// <summary>
        /// Validates strings based on a given min and max lenght, if string fails validation, returns null.
        /// </summary>
        /// <param name="input">String to be validated.</param>
        /// <param name="minLenght">Minimum lenght of string (inclusive).</param>
        /// <param name="maxLenght">Maximum lenght of string (inclusive).</param>
        /// <returns>Validated string or null.</returns>
        public static string StringLenghtValidator(string input, int minLenght, int maxLenght)
        {
            if (input.Length > maxLenght || input.Length < minLenght)
            {
                bool select = input.Length > maxLenght;
                throw new ArgumentException($"Invalid input, string is of lenght {input.Length}, whereas {(select ? "Max Lenght" : "Min Lenght")} is {(select ? maxLenght : minLenght)}");
            }
            else
                return input;
        }
        public static string ConsoleStringLenghtValidator(string prompt,int minLenght, int maxLenght, string additionalPrompt = "")
        {
            while (true)
            {
                string input = ConsoleUtils.GetInputString(prompt, additionalPrompt, false);
                if (input.Length > maxLenght || input.Length < minLenght)
                {
                    bool select = input.Length > maxLenght;
                    Console.WriteLine($"Invalid input, string is of lenght {input.Length}, whereas {(select ? "Max Lenght" : "Min Lenght")} is {(select ? maxLenght : minLenght)}");
                }
                else
                    return input;
            }
        }
    }
}