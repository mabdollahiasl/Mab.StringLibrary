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

        public Dictionary<string, double> Variables { get; }
        private List<FunctionProcessor> Functions { get; }

        public ParameterNode Node { get; set; }

        public FormulaParser(string formulaText)
        {
            FormulaText = formulaText;
            FormulaTextWithoutSpace = RemoveUslessSpaces();
            Functions = new List<FunctionProcessor>();
            Init();
        }
        private string RemoveUslessSpaces()
        {
            string withoutDoublicate = FormulaText.RemoveDuplicateSpaces();
            withoutDoublicate = Regex.Replace(withoutDoublicate, FormulaConstants.UselessSpace, string.Empty);
            return withoutDoublicate;
        }
        private void Init()
        {
            Node = new ParameterNode(FormulaTextWithoutSpace);
            ParseFunctions(Node);
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
        private void ParseFunctions(ParameterNode root)
        {
            string formula = root.Formula;

            Regex regex = new Regex(FormulaConstants.FunctionStartRegex);
            Match match = regex.Match(formula);
            StringBuilder parameterizedFormula = new StringBuilder();
            int start = 0;
            int functionIndex = 0;
            while (match.Success)
            {
                FunctionProcessor function = new FunctionProcessor(match);
                function.ProcessFunction(formula);
                parameterizedFormula.Append(formula.Substring(start, match.Index - start));
                parameterizedFormula.Append("{" + functionIndex + "}");
                var experssionFunction = new FunctionNode(function.Function, function.FunctionName);
                root.Parts.Add(experssionFunction);
                foreach (var item in function.FunctionParts) //add function parameters to experssion tree
                {
                    var experssionPart = new ParameterNode(item);
                    experssionFunction.Parts.Add(experssionPart);
                    ParseFunctions(experssionPart);
                }
                start = function.FunctionContentEndIndex + 1;//add 1 for ')'
                functionIndex++;
                match = regex.Match(formula, function.FunctionContentEndIndex);
            }

            parameterizedFormula.Append(formula.Substring(start, formula.Length - start));// add reamin part of string

            root.ParameterizedFormat=parameterizedFormula.ToString();
        }
        private IEnumerable<IFormulaPart> GetStringParts()
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

                if (Variables.ContainsKey(item.VariableName))
                {
                    item.VariableValue = Variables[item.VariableName];
                }
            }
        }
    }
}
