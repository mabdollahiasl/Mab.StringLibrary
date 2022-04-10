using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mab.StringLibrary.Formula.Expressions
{
    public class FormulaNode : ExpressionNode
    {
        public string ParameterizedFormat { get; set; }
        public string CalculatedFormula { get;private set; }
        public void UpdateCalculatedFormula()
        {
            CalculatedFormula = string.Format(ParameterizedFormat, ParametersValues.Cast<object>().ToArray());
        }
            

        public FormulaNode(string formula) : base(formula)
        {
        }
        public override string ToString()
        {
            return "Parameter: " + Formula;
        }
    }
}
