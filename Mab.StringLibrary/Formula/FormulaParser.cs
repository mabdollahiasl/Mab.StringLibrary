using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using Mab.StringLibrary.Formula.Exception;

namespace Mab.StringLibrary.Formula
{
    public class FormulaParser
    {        
       


      

        public string FormulaText { get; }
        private string FormulaTextWithoutSpace { get; }


        public FormulaParser(string formulaText)
        {
            FormulaText = formulaText;
            FormulaTextWithoutSpace = FormulaText.RemoveSpaces();
        }
        public string GetFormatedFormula()
        {
            int position = 0;
            string currentPart;
            StringBuilder formated = new StringBuilder();
            Regex regex = new Regex(FormulaConstants.OpratorRegex);
            Match match = regex.Match(FormulaTextWithoutSpace);
            while (match.Success)
            {
                currentPart = FormulaTextWithoutSpace.Substring(position, match.Index - position);
                formated.Append(currentPart);
                formated.Append(match.Value.AddOneSpaceToBathSide());
                position = match.Index + match.Length;
                match = match.NextMatch();
            }
            currentPart = FormulaTextWithoutSpace.Substring(position, FormulaTextWithoutSpace.Length - position);
            formated.Append(currentPart);


            return formated.ToString();
        }
        public IEnumerable<IFormulaPart> GetStringParts()
        {
            List<IFormulaPart> parts = new List<IFormulaPart>();
            string formated = GetFormatedFormula();
        

            Regex regex = new Regex(FormulaConstants.FormulaRegex);
         
            Match match = regex.Match(formated);
            StringBuilder matchedString = new StringBuilder();
           
            while (match.Success)
            {
                var part = FormulaPartFactory.CreatePart(match);
                parts.Add(part);
                matchedString.Append(match.Value);
                match = match.NextMatch();
            }
            if (matchedString.ToString() != formated)// has invalid chars
            {
                throw new FormulaParseException("invalid formula!", null);
            }
         
            return parts;
        }
        public decimal Calculate()
        {
            IEnumerable<IFormulaPart> parts = GetStringParts();
            var postConverter = new PostfixConverter(parts);
            postConverter.ConvertToPostFix();
            return postConverter.ProcessPostfix();
        }

    }
}
