using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary
{
    public static class ConverterExtenssions
    {

        /// <summary>
        /// Converts the string representation of a number to its single-precision floating-point number equivalent.
        /// </summary>
        /// <param name="source">A string that contains a number to convert.</param>
        /// <param name="defaultValue">A value that return if string is not valid.</param>
        /// <returns></returns>
        public static float ToSingle(this string source, float? defaultValue = null)
        {
            return defaultValue == null ? float.Parse(source) : float.TryParse(source, out float result) ? result : defaultValue.Value;
        }

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
        public static short ToShort(this string source, short? defaultValue = null)
        {
            return defaultValue == null ? short.Parse(source) : short.TryParse(source, out short result) ? result : defaultValue.Value;
        }

        /// <summary>
        /// Converts the string representation of a number to its number equivalent.
        /// </summary>
        /// <param name="source">A string that contains a number to convert.</param>
        /// <param name="defaultValue">A value that return if string is not valid.</param>
        /// <returns></returns>
        public static ushort ToUShort(this string source, ushort? defaultValue = null)
        {
            return defaultValue == null ? ushort.Parse(source) : ushort.TryParse(source, out ushort result) ? result : defaultValue.Value;
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

        /// <summary>
        /// Converts the string representation of a number to its number equivalent.
        /// </summary>
        /// <param name="source">A string that contains a number to convert.</param>
        /// <param name="defaultValue">A value that return if string is not valid.</param>
        /// <returns></returns>
        public static long ToLong(this string source, long? defaultValue = null)
        {
            return defaultValue == null ? long.Parse(source) : long.TryParse(source, out long result) ? result : defaultValue.Value;
        }

        /// <summary>
        /// Converts the string representation of a number to its number equivalent.
        /// </summary>
        /// <param name="source">A string that contains a number to convert.</param>
        /// <param name="defaultValue">A value that return if string is not valid.</param>
        /// <returns></returns>
        public static uint ToUInteger(this string source, uint? defaultValue = null)
        {
            return defaultValue == null ? uint.Parse(source) : uint.TryParse(source, out uint result) ? result : defaultValue.Value;
        }

        /// <summary>
        /// Converts the string representation of a number to its number equivalent.
        /// </summary>
        /// <param name="source">A string that contains a number to convert.</param>
        /// <param name="defaultValue">A value that return if string is not valid.</param>
        /// <returns></returns>
        public static ulong ToULong(this string source, ulong? defaultValue = null)
        {
            return defaultValue == null ? ulong.Parse(source) : ulong.TryParse(source, out ulong result) ? result : defaultValue.Value;
        }


        /// <summary>
        /// Converts the string representation of a number to its number equivalent.
        /// </summary>
        /// <param name="source">A string that contains a number to convert.</param>
        /// <param name="defaultValue">A value that return if string is not valid.</param>
        /// <returns></returns>
        public static byte ToByte(this string source, byte? defaultValue = null)
        {
            return defaultValue == null ? byte.Parse(source) : byte.TryParse(source, out byte result) ? result : defaultValue.Value;
        }

        /// <summary>
        /// Converts the string representation of a number to its number equivalent.
        /// </summary>
        /// <param name="source">A string that contains a number to convert.</param>
        /// <param name="defaultValue">A value that return if string is not valid.</param>
        /// <returns></returns>
        public static sbyte ToSByte(this string source, sbyte? defaultValue = null)
        {
            return defaultValue == null ? sbyte.Parse(source) : sbyte.TryParse(source, out sbyte result) ? result : defaultValue.Value;
        }

        /// <summary>
        /// Converts the string representation of a decimal number to its decimal number equivalent.
        /// </summary>
        /// <param name="source">A string that contains a number to convert.</param>
        /// <param name="defaultValue">A value that return if string is not valid.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string source, decimal? defaultValue = null)
        {
            return defaultValue == null ? decimal.Parse(source) : decimal.TryParse(source, out decimal result) ? result : defaultValue.Value;
        }

       
    }
}
