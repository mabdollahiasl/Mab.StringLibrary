using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula
{
    internal static class FormulaEnumerableExtensions
    {
        public static string ToStringFormula(this IEnumerable<IFormulaPart > parts)
        {
            StringBuilder partsString = new StringBuilder(); 
            foreach (var item in parts)
            {
                partsString.Append(item.ToString());
            }
            return partsString.ToString();
        }
        public static string ToStringParameters(this IEnumerable<double> parameters)
        {
            StringBuilder partsString = new StringBuilder();
            foreach (var item in parameters)
            {
                partsString.Append(item.ToString().AddOneSpaceToEnd());
            }
            return partsString.ToString().Trim();
        }
    }
}
