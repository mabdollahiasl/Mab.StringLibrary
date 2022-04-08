using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mab.StringLibrary.Formula
{
    internal class FormulaPartFactory
    {
        public static IFormulaPart[] CreateParts(Match match)
        {
            IFormulaPart part;
            if (match.Groups[FormulaConstants.RegexOpratorGroupName].Success)
            {
                part = new OperatorPart(match.Value.Trim());
            }else if (match.Groups[FormulaConstants.RegexNumberGroupName].Success)
            {
                part = new NumberPart(match.Value.Trim());
            }
            else if (match.Groups[FormulaConstants.RegexVariableGroupName].Success)
            {
                part = new NumberPart(match.Value.Trim(), true);
            }
            else if (match.Groups[FormulaConstants.RegexCloseGroupName].Success)
            {
                part = new ParenthesesPart(match.Value.Trim());
            }
            else if (match.Groups[FormulaConstants.RegexOpenGroupName].Success)
            {
                part = new ParenthesesPart(match.Value.Trim());
                if((part as ParenthesesPart).IsOpen && (part as ParenthesesPart).IsNegative) //handle negative parantesisd
                {
                    NumberPart NegativeOne = new NumberPart(FormulaConstants.NegativeOne);
                    OperatorPart multiply = new OperatorPart(FormulaConstants.MutiplySymbol);
                    return new IFormulaPart[] { NegativeOne, multiply, part };
                }
            }
            else
            {
                throw new ArgumentException();
            }
            return new IFormulaPart[] {part};
        }
    }
}
