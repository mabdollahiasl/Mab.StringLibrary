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

        public string Part { get; }
        public decimal Value { get => decimal.Parse(Part); }
      

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
