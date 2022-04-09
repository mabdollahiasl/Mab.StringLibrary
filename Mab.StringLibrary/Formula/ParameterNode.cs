using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula
{
    public class ParameterNode : ExperssionNode
    {
        public string ParameterizedFormat { get; set; }

        public ParameterNode(string formula) : base(formula)
        {
        }
        public override string ToString()
        {
            return "Parameter: " + Formula;
        }
    }
}
