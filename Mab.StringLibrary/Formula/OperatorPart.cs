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
        public int Precedence
        {
            get
            {
                switch (Part)
                {
                    case FormulaConstants.AddSymbol:
                        return 1;
                    case FormulaConstants.MinusSymbol:
                        return 1;
                    case FormulaConstants.PowerSymbol:
                        return 3;
                    case FormulaConstants.DivdeSymbol:
                        return 2;
                    case FormulaConstants.MutiplySymbol:
                        return 2;
                    default:
                        return -1;
                }
            }
        }
        public NumberPart Do(NumberPart left, NumberPart right)
        {
            switch (Type)
            {
                case OperatorType.Add:
                    return new NumberPart((right.Value + left.Value).ToString());
                case OperatorType.Power:
                    return new NumberPart(Math.Pow((double)right.Value, (double)left.Value).ToString());
                case OperatorType.Multiply:
                    return new NumberPart((right.Value * left.Value).ToString());
                case OperatorType.Divide:
                    return new NumberPart((right.Value / left.Value).ToString());
                case OperatorType.Modulus:
                    return new NumberPart((right.Value - left.Value).ToString());
            }
            throw new NotImplementedException();

        }
        public override string ToString()
        {
            return Part;
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
