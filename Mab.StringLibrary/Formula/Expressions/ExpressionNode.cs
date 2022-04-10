using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula.Expressions
{
    public class ExpressionNode
    {
        public string Formula { get;private set; }

        public List<ExpressionNode> ChildNodes { get; private set; }
        public List<double> ParametersValues { get; }

        public double Value { get; set; }

        public ExpressionNode(string formula)
        {
            this.Formula = formula;
            ChildNodes = new List<ExpressionNode>();
            ParametersValues = new List<double>();
        }
        public override string ToString()
        {
            return Formula;
        }
    }
}
