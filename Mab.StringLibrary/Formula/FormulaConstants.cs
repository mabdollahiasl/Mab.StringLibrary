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

        private const string OrRegex = "|";
        public const string OpratorRegex = @"(?<![/*+-])((?<!(^|\())[/*+-])";

        public const string RegexOpenGroupName = "open";
        public const string RegexCloseGroupName = "close";
        public const string RegexnumberGroupName = "number";
        public const string RegexOpratorGroupName = "oprator";

        public const string OpenParenthesesRegex = @"(?<open>([+-]?\())";
        public const string CloseParenthesesRegex = @"(?<close>[\)])";
        public const string DesimalNumberRegex = @"(?<number>([+-]?((\d+(\.\d*)?)|(\.\d+))))";
        public const string FormatedOpratorRegex = @"(?<oprator>( [+*/-] ))";


        public const string FormulaRegex = OpenParenthesesRegex + OrRegex +
                                           CloseParenthesesRegex + OrRegex +
                                           DesimalNumberRegex + OrRegex +
                                           FormatedOpratorRegex;
    }
}
