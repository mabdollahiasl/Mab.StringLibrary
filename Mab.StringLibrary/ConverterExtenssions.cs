using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary
{
    public static class ConverterExtenssions
    {

        /// <summary>
        /// Converts the string representation of a number to its double-precision floating-point number equivalent.
        /// </summary>
        /// <param name="source">A string that contains a number to convert.</param>
        /// <param name="defaultValue">A value that return if string is not valid.</param>
        /// <returns></returns>
        public static double ToDouble(this string source,double? defaultValue=null)
        {
            return defaultValue == null ? double.Parse(source) : double.TryParse(source, out double result) ? result : defaultValue.Value;
        }

        /// <summary>
        /// Converts the string representation of a number to its number equivalent.
        /// </summary>
        /// <param name="source">A string that contains a number to convert.</param>
        /// <param name="defaultValue">A value that return if string is not valid.</param>
        /// <returns></returns>
        public static int ToInteger(this string source, int? defaultValue = null)
        {
            return defaultValue == null ? int.Parse(source) : int.TryParse(source, out int result) ? result : defaultValue.Value;
        }
    }
}
