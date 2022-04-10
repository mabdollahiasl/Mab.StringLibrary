using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using Mab.StringLibrary.Formula.Exception;
using Mab.StringLibrary.Formula.Expressions;

namespace Mab.StringLibrary.Formula
{
    public delegate double CustomFunction(string functionName, double[] pars);
    internal class FormulaParser
    {
        public string FormulaText { get; }
        private string FormulaTextWithoutSpace { get; }

        public Dictionary<string, double> Variables { get; }
        public CustomFunction FunctionValueResolver { get; }
        public FormulaNode Node { get; set; }
        public FormulaParser(string formulaText,CustomFunction functionValueResolver=null)
        {
            FormulaText = formulaText;
            FormulaTextWithoutSpace = RemoveUslessSpaces();
            Variables = new Dictionary<string, double>();
            this.FunctionValueResolver = functionValueResolver;
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
            Node = new FormulaNode(FormulaTextWithoutSpace);
            ParseFunctions(Node);
        }
        public string GetFormatedFormula(string formulaTextWithoutSpace)
        {
            int position = 0;
            string currentPart;
            StringBuilder formated = new StringBuilder();
            Regex regex = new Regex(FormulaConstants.OpratorRegex);
            Match match = regex.Match(formulaTextWithoutSpace);

            while (match.Success)
            {
                currentPart = formulaTextWithoutSpace.Substring(position, match.Index - position);
                formated.Append(currentPart);
                formated.Append(match.Value.AddOneSpaceToBathSide());
                position = match.Index + match.Length;
                match = match.NextMatch();
            }
            currentPart = formulaTextWithoutSpace.Substring(position, formulaTextWithoutSpace.Length - position);
            formated.Append(currentPart);
            return formated.ToString();
        }
        private void ParseFunctions(FormulaNode root)
        {
            string formula = root.Formula;

            Regex regex = new Regex(FormulaConstants.FunctionStartRegex);
            Match match = regex.Match(formula);
            StringBuilder parameterizedFormula = new StringBuilder();
            int start = 0;
            int functionIndex = 0;
            while (match.Success)
            {
                FunctionParser function = new FunctionParser(match);
                function.Parse(formula);
                parameterizedFormula.Append(formula.Substring(start, match.Index - start));
                parameterizedFormula.Append("{" + functionIndex + "}");
                var experssionFunction = new FunctionNode(function.Experssion, function.Name);
                root.ChildNodes.Add(experssionFunction);
                foreach (var item in function.Parameters) //add function parameters to experssion tree
                {
                    var experssionPart = new FormulaNode(item);
                    experssionFunction.ChildNodes.Add(experssionPart);
                    ParseFunctions(experssionPart);
                }
                start = function.ContentEndIndex + 1;//add 1 for ')'
                functionIndex++;
                match = regex.Match(formula, function.ContentEndIndex);
            }

            parameterizedFormula.Append(formula.Substring(start, formula.Length - start));// add reamin part of string

            root.ParameterizedFormat=parameterizedFormula.ToString();
        }
        private IEnumerable<IFormulaPart> GetStringParts(string formulaWithoutSpace)
        {
            List<IFormulaPart> parts = new List<IFormulaPart>();
            string formated = GetFormatedFormula(formulaWithoutSpace);

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
        private double Calculate(ExpressionNode node)
        {
            foreach (var item in node.ChildNodes)
            {
                node.ParametersValues.Add(Calculate(item));
            }
            if (node is FormulaNode parameterNode)
            {
                parameterNode.UpdateCalculatedFormula();
                parameterNode.Value = Calculate(parameterNode.CalculatedFormula);
                return parameterNode.Value;
            }
            else if(node is FunctionNode functionNode)
            {
                functionNode.Value = CallFunction(functionNode.FunctionName, functionNode.ParametersValues);
                return functionNode.Value;
            }
            throw new NotImplementedException();
        }

        private double Calculate(string calculatedFormula)
        {
            IEnumerable<IFormulaPart> parts = GetStringParts(calculatedFormula);
            UpdateVariableValues(parts);
            var postConverter = new PostfixConverter(parts);
            postConverter.ConvertToPostFix();
            return postConverter.ProcessPostfix();
        }

        private double CallFunction(string functionName, List<double> parametersValues)
        {
            if (FunctionValueResolver == null)
            {
                throw new ArgumentNullException("functionValueResolver");
            }
            return FunctionValueResolver(functionName, parametersValues.ToArray());
        }

        public double Calculate()
        {
            Calculate(Node);
            return Node.Value;
        }

        private void UpdateVariableValues(IEnumerable<IFormulaPart> parts)
        {
            foreach (NumberPart item in parts.Where(p => p is NumberPart && (p as NumberPart).IsVariable))
            {

                if (Variables.ContainsKey(item.VariableName))
                {
                    item.VariableValue = Variables[item.VariableName];
                }else
                {
                    throw new FormulaParseException("variable not found:" + item.VariableName, null);
                }
            }
        }
    }
}
