using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula.Exception
{
    public class FormulaParseException:System.Exception
    {
        public FormulaParseException(string message, System.Exception innerException) : base(message, innerException)
        {

        }
        public FormulaParseException()
        {

        }
    }
}
