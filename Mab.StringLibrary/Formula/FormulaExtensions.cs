using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary.Formula
{
    public static class FormulaExtensions
    {
        /// <summary>
        /// Parse a formula like ʻ5+(8*(5+2))ʼ to double
        /// </summary>
        /// <param name="formula">a formula string</param>
        /// <returns>the result of formula</returns>
        public static double ParseAsFormula(this string formula)
        {
            FormulaParser parser = new FormulaParser(formula);
            return parser.Calculate();
        }

        /// <summary>
        /// Parse a formula that contains a custom function like ʻ5+Sin(0.2+0.1)+Abs(Sin(0.2) *2)ʼ to double
        /// </summary>
        /// <param name="formula">a formula that contans functions like ʻ5+Sin(0.2+0.1)+Abs(Sin(0.2) *2)ʼ</param>
        /// <param name="functionResolver">a function like double Function(string functionName,params double[] parameters) for processing custom function</param>
        /// <returns>the result of formula</returns>
        public static double ParseAsFormula(this string formula,CustomFunction functionResolver)
        {
            FormulaParser parser = new FormulaParser(formula,functionResolver);
            return parser.Calculate();
        }
        /// <summary>
        /// Parse a formula that contains a custom function like ʻx+Sin(0.2+0.1)+Abs(Sin(0.2) *2)ʼ and some variables to double
        /// </summary>
        /// <param name="formula">a formula that contans functions and variables like ʻx+Sin(0.2+0.1)+Abs(Sin(0.2) *2)ʼ</param>
        /// <param name="variables">a dictionary that contains key value pairs of variables</param>
        /// <param name="functionResolver">a function like double Function(string functionName,params double[] parameters) for processing custom function</param>
        /// <returns></returns>
        public static double ParseAsFormula(this string formula, Dictionary<string, double> variables, CustomFunction functionResolver)
        {
            FormulaParser parser = new FormulaParser(formula, functionResolver);
            foreach (var item in variables)
            {
                parser.Variables[item.Key] = item.Value;
            }
            return parser.Calculate();
        }
        /// <summary>
        /// Parse a formula that contains some variables like ʻx + y + -(5+y)ʼ to double
        /// </summary>
        /// <param name="formula">a formula like ʻx + y + -(5+y)ʼ</param>
        /// <param name="variables">a dictionary that contains key value pairs of variables</param>
        /// <returns></returns>
        public static double ParseAsFormula(this string formula, Dictionary<string, double> variables)
        {
            FormulaParser parser = new FormulaParser(formula, null);
            foreach (var item in variables)
            {
                parser.Variables[item.Key] = item.Value;
            }
            return parser.Calculate();
        }
    }
}
