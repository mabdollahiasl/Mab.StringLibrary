using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mab.StringLibrary.Formula
{
    internal class FormulaPartFactory
    {
        public static IFormulaPart CreatePart(Match match)
        {
            IFormulaPart part;
            if (match.Groups[FormulaConstants.RegexOpratorGroupName].Success)
            {
                part = new OperatorPart(match.Value.Trim());
            }else if (match.Groups[FormulaConstants.RegexnumberGroupName].Success)
            {
                part = new NumberPart(match.Value.Trim());
            }else if (match.Groups[FormulaConstants.RegexCloseGroupName].Success)
            {
                part = new ParenthesesPart(match.Value.Trim());
            }
            else if (match.Groups[FormulaConstants.RegexOpenGroupName].Success)
            {
                part = new ParenthesesPart(match.Value.Trim());
            }
            else
            {
                throw new ArgumentException();
            }
            return part;
        }
    }
}
