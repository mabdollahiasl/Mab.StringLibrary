using Mab.StringLibrary.Formula.Exception;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mab.StringLibrary.Formula
{
    public class FunctionProcessor
    {
        private Match _match;

        public int ParameterCount { get; private set; }
        public string AsignedName { get; set; }
        public string FunctionName { get; private set; }
        public int FunctionContentStartIndex { get; private set; }
        public int FunctionContentEndIndex { get; private set; }
        public int FunctionContentLength { get; private set; }
        private string FunctionContent { get; set; }
        public string Function { get; set; }

        public string[] FunctionParts { get; private set; }



        public FunctionProcessor(Match match)
        {
            this._match = match;
        }
        public void ProcessFunction(string formulaWithoutSpace)
        {
            int start = _match.Index + _match.Length;
            int open = 1;
            while (start < formulaWithoutSpace.Length && open > 0) //search for function )
            {
                string current = formulaWithoutSpace[start].ToString();
                if (current == FormulaConstants.OpenSymbol)
                {
                    open++;
                }
                else if (current == FormulaConstants.CloseSymbol)
                {
                    open--;
                }
                start++;
            }
            if (open > 0)
            {
                throw new FormulaParseException(") not found!", null);
            }
            FunctionName = _match.Value.Substring(0, _match.Length - 1);
            FunctionContentStartIndex = _match.Index + _match.Length;
            FunctionContentEndIndex = start - 1;
            FunctionContentLength = FunctionContentEndIndex - FunctionContentStartIndex;
            FunctionContent = formulaWithoutSpace.Substring(FunctionContentStartIndex,
                                                            FunctionContentLength);
            FunctionParts = FunctionContent.Split(FormulaConstants.ParameterSymbol);
            Function = formulaWithoutSpace.Substring(_match.Index, start - _match.Index);
            ParameterCount = FunctionParts.Length;

         

        }
    }
}
