using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula
{
    public class ExperssionNode
    {
        public string Formula { get;private set; }

        public List<ExperssionNode> Parts { get; private set; }
        public ExperssionNode(string formula)
        {
            this.Formula = formula;
            Parts = new List<ExperssionNode>();
        }
        public override string ToString()
        {
            return Formula;
        }
    }
}
