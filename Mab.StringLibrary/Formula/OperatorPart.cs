using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula
{
    internal class OperatorPart : IFormulaPart
    {
        public OperatorPart(string part)
        {
            Part = part;
        }
        public string Part { get; }
        public OperatorType Type
        {
            get
            {
                switch (Part)
                {
                    case FormulaConstants.AddSymbol:
                        return OperatorType.Add;
                    case FormulaConstants.MinusSymbol:
                        return OperatorType.Modulus;
                    case FormulaConstants.PowerSymbol:
                        return OperatorType.Power;
                    case FormulaConstants.DivdeSymbol:
                        return OperatorType.Divide;
                    case FormulaConstants.MutiplySymbol:
                        return OperatorType.Multiply;
                    default:
                        return OperatorType.Add;
                }
            }
        }
    }
    public enum OperatorType
    {
        Power,
        Multiply,
        Divide,
        Add,
        Modulus,
    }
}
