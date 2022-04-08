using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula
{
    internal class NumberPart : IFormulaPart
    {
        public NumberPart(string part)
        {
            Part = part;
        }
        public NumberPart(string part,bool isVariable)
        {
            Part = part;
            IsVariable = isVariable;
        }

        public string VariableName { 
            get
            {
                if(Part.StartsWith(FormulaConstants.AddSymbol) ||
                   Part.StartsWith(FormulaConstants.MinusSymbol))
                {
                    return Part.Substring(1);
                }else
                {
                    return Part;
                }
            }
        }
        public double VariableValue { get; internal set; }
        public string Part { get; }
        public bool IsVariable { get; }
        public double Value
        {
            get
            {
                return IsVariable ? Part.StartsWith(FormulaConstants.MinusSymbol) ? -VariableValue : VariableValue : double.Parse(Part);
            }
        }
      

        public bool IsNegative
        {
            get
            {
                return Value < 0;
            }
        }
        public override string ToString()
        {
            return Part;
        }
        
    }
}
