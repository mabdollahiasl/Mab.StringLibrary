using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary
{
    public static class SpaceExtenssions
    {
        /// <summary>
        /// Convert doublicate spaces to just one space
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveDuplicateSpaces(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }
            StringBuilder result = new StringBuilder();
            bool foundSpace = false;
            foreach (var item in source)
            {
                if (item == Statics.SpaceChar && !foundSpace)
                {
                    foundSpace = true;
                    result.Append(item);
                }
                else if (item != Statics.SpaceChar)
                {
                    foundSpace = false;
                    result.Append(item);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Remove all spaces from string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveSpaces(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }
            return source.Replace(Statics.Space,string.Empty);
        }
        /// <summary>
        /// Adds just one space to start of string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string AddOneSpaceToStart(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }
            return Statics.Space + source.TrimStart();
        }
        /// <summary>
        /// Adds just one space to end of string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string AddOneSpaceToEnd(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }
            return source.TrimEnd()+ Statics.Space;
        }
        /// <summary>
        /// Adds just one space to both side of string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string AddOneSpaceToBathSide (this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }
            return Statics.Space + source.Trim() + Statics.Space;
        }

    }
}
