using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Utils
{
    internal static class IntExtender
    {
        /// <summary>
        /// Returns false for 0, true for any other value
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <returns></returns>
        public static bool ToBool(this int value)
        {
            if (value == 0)
                return false;
            return true;
        }
    }
}
