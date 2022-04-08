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

        public Dictionary<string,double> Variables { get; }

        public FormulaParser(string formulaText)
        {
            FormulaText = formulaText;
            FormulaTextWithoutSpace = RemoveUslessSpaces();
            Variables = new Dictionary<string,double>();
        }
        private string RemoveUslessSpaces()
        {
            string withoutDoublicate=FormulaText.RemoveDuplicateSpaces();
            withoutDoublicate=Regex.Replace(withoutDoublicate,FormulaConstants.UselessSpace,string.Empty);
            return withoutDoublicate;
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
                var part = FormulaPartFactory.CreateParts(match);
                parts.AddRange(part);
                matchedString.Append(match.Value);
                match = match.NextMatch();
            }
            if (matchedString.ToString() != formated)// has invalid chars
            {
                throw new FormulaParseException("invalid formula!", null);
            }
         
            return parts;
        }
        public double Calculate()
        {
            IEnumerable<IFormulaPart> parts = GetStringParts();
            UpdateVariableValues(parts);
            var postConverter = new PostfixConverter(parts);
            postConverter.ConvertToPostFix();
            return postConverter.ProcessPostfix();
        }

        private void UpdateVariableValues(IEnumerable<IFormulaPart> parts)
        {
            foreach (NumberPart item in parts.Where(p => p is NumberPart))
            {
                
                if(Variables.ContainsKey(item.VariableName))
                {
                    item.VariableValue = Variables[item.VariableName];
                }
            }
        }
    }
}
