﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula.Expressions
{
    internal class FunctionNode : ExpressionNode
    {
        public string FunctionName { get; }
        public FunctionNode(string formula,string functionName) : base(formula)
        {
            this.FunctionName = functionName;
        }
        public override string ToString()
        {
            return "Function: " +Formula;
        }
    }
}
