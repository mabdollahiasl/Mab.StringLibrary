using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula
{
    internal static class FormulaEnumExtenssions
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
    }
}
