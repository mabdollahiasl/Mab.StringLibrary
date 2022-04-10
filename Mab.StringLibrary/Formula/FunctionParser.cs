using Mab.StringLibrary.Formula.Exception;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mab.StringLibrary.Formula
{
    public class FunctionParser
    {
        private readonly Match _match;

        public int ParameterCount { get; private set; }
        public string Name { get; private set; }
        public int ContentStartIndex { get; private set; }
        public int ContentEndIndex { get; private set; }
        public int ContentLength { get; private set; }
        public string Content { get; private set; }
        public string Experssion { get; set; }

        public IEnumerable<string> Parameters { get; private set; }



        public FunctionParser(Match match)
        {
            this._match = match;
        }
        public void Parse(string formulaWithoutSpace)
        {
            int start = _match.Index + _match.Length;
            int open = 1;
            List<string> parts = new List<string>();
            StringBuilder currentPart = new StringBuilder();
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
                if (current == FormulaConstants.ParameterSymbol && open == 1)
                {
                    parts.Add(currentPart.ToString());
                    currentPart.Clear();
                }
                else
                {
                    currentPart.Append(current);
                }
                start++;
            }
            if (open > 0)
            {
                throw new FormulaParseException(") not found!", null);
            }
            if (currentPart.Length > 1)// remove ) from current parmeter of function
            {
                currentPart.Remove(currentPart.Length - 1, 1);
                parts.Add(currentPart.ToString());
            }
            Name = _match.Value.Substring(0, _match.Length - 1);
            ContentStartIndex = _match.Index + _match.Length;
            ContentEndIndex = start - 1;
            ContentLength = ContentEndIndex - ContentStartIndex;
            Content = formulaWithoutSpace.Substring(ContentStartIndex,
                                                            ContentLength);
            Parameters = parts.ToArray();
            Experssion = formulaWithoutSpace.Substring(_match.Index, start - _match.Index);
            ParameterCount = parts.Count;



        }
    }
}
