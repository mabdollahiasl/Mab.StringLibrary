using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula
{
    internal class FormulaConstants
    {
        public const string MutiplySymbol = "*";
        public const string AddSymbol = "+";
        public const string MinusSymbol = "-";
        public const string DivdeSymbol = "/";
        public const string PowerSymbol = "^";
        public const string OpenSymbol = "(";
        public const string CloseSymbol = ")";
        public const string ParameterSymbol = ",";

        public const string AllOpratorRegexRange = "[/*^+-]";
        private const string OrRegex = "|";
        public const string OpratorRegex = @"(?<!" + AllOpratorRegexRange + @")((?<!(^|\())" + AllOpratorRegexRange + ")";

        public const string RegexOpenGroupName = "open";
        public const string RegexCloseGroupName = "close";
        public const string RegexNumberGroupName = "number";
        public const string RegexOpratorGroupName = "oprator";
        public const string RegexVariableGroupName = "var";

        public const string OpenParenthesesRegex = @"(?<open>([+-]?\())";
        public const string CloseParenthesesRegex = @"(?<close>[\)])";
        public const string DecimalNumberRegex = @"(?<number>([+-]?((\d+(\.\d*)?)|(\.\d+))))";
        public const string FormatedOpratorRegex = @"(?<oprator>(\s" + AllOpratorRegexRange + @"\s))";
        public const string VariableRegex = @"(?<var>([-+]?[a-zA-Z_]+\d*))";
        public const string FunctionStartRegex = @"(?<funcstart>([a-zA-Z_]+\d*)\()";

        public const string UselessSpace = @"((?<!(\w|\.))\s+)|(\s+(?!(\w|\.)))";


        public const string FormulaRegex = OpenParenthesesRegex + OrRegex +
                                           CloseParenthesesRegex + OrRegex +
                                           DecimalNumberRegex + OrRegex +
                                           FormatedOpratorRegex + OrRegex +
                                           VariableRegex;
        public const string NegativeOne = "-1";
    }
}
