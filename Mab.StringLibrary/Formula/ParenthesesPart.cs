using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Mab.StringLibrary.Formula
{
    internal class ParenthesesPart : IFormulaPart
    {
        public ParenthesesPart(string part)
        {
            Part = part;
        }

        public string Part { get; }
        public bool IsNegative { get => Part.StartsWith(FormulaConstants.MinusSymbol); }
        public bool IsOpen { get => Part.Last().ToString() == FormulaConstants.OpenSymbol; }

    }
}
