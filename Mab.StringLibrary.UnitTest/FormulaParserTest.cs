using Mab.StringLibrary.Formula;
using Mab.StringLibrary.Formula.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Mab.StringLibrary.UnitTest
{
    public class FormulaParserTest
    {
        [Fact]
        public void One_Positive_Number()
        {
            double number = 58;

            FormulaParser parser = new(number.ToString());
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void One_Negative_Number()
        {
            double number = -58;

            FormulaParser parser = new(number.ToString());
            Assert.Equal(number, parser.Calculate());
        }

        [Fact]
        public void One_Negative_Real_Number()
        {
            double number = -58.545;

            FormulaParser parser = new(number.ToString());
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void One_Positive_Real_Number()
        {
            double number = 58.545;

            FormulaParser parser = new(number.ToString());
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void One_Explicit_Positive_Real_Number()
        {
            string number = "+58.545";

            FormulaParser parser = new(number);
            Assert.Equal(double.Parse(number), parser.Calculate());
        }

        [Fact]
        public void Simple_Formula()
        {
            //Parentheses
            double number = -4 + 5.0 * 2.0 - 2;
            string formula = "-4+5*2-2";
            FormulaParser parser = new(formula);
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void Simple_Real_Formula()
        {
            //Parentheses
            double number = -4.5 + 5.2 * 2.0 - 2.1;
            string formula = "-4.5+5.2*2-2.1";
            FormulaParser parser = new(formula);
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void Parentheses_Real_Formula()
        {
            //Parentheses
            double number = -4.5 + 5.2 * 2.0 - 2.1 * (8.0 / 999.2) + ((3556.0 + 78.0) / 5.0);
            string formula = "-4.5+5.2*2-2.1*(8/999.2)+((3556+78)/5)";
            FormulaParser parser = new(formula);
            Assert.Equal(number, parser.Calculate());
        }

      

        [Fact]
        public void Parentheses_Real_Formula_UselessSpace()
        {
            //Parentheses
            double number = -4.5 + 5.2 * 2.0 - 2.1 * (8.0 / 999.2) + ((3556 + 78.0) / 5.0);
            string formula = "-  4.5   +   5.2*2  -  2.1  *  (8/999.2)+   (   (3556+  78)  /5   )";
            FormulaParser parser = new(formula);
            Assert.Equal(number, parser.Calculate());
        }

        [Fact]
        public void Parentheses_Real_Number_Without_Zero_Decimal_Formula()
        {
            //Parentheses
            double number = -4.5 + .2 * 2.0 - 2.0 * (8 / 999.2) + ((3556 + 78.0) / 5.0);
            string formula = "-4.5+.2*2-2.*(8/999.2)+((3556+78)/5)";
            FormulaParser parser = new(formula);
            Assert.Equal(number, parser.Calculate());
        }

        [Fact]
        public void Parentheses_Real_Number_Power_Formula()
        {
            //Parentheses
            double number = -4.5 + .2 * 2 - 2.0 * (8 / 999.2) + ((Math.Pow(35, 2.2) + 78.0) / 5);
            string formula = "-4.5+.2*2-2.*(8/999.2)+((35^2.2+78)/5)";
            FormulaParser parser = new(formula);
            Assert.Equal(number, parser.Calculate());
        }

        [Fact]
        public void Parentheses_Negative_Real_Number_Power_Formula()
        {
            //Parentheses
            double number = -4.5 + .2 * 2 - 2.0 * -(8 / 999.2) + (-(Math.Pow(35, 2.2) + 78.0) / 5);
            string formula = "-4.5+.2*2-2.*-(8/999.2)+(-(35^2.2+78)/5)";
            FormulaParser parser = new(formula);
            Assert.Equal(number, parser.Calculate());
        }

        [Fact]
        public void Parentheses_NotValid_Formula()
        {
            //Parentheses
            Assert.Throws<FormulaParseException>(() =>
            {
                string formula = "((3556+78)/)";
                FormulaParser parser = new(formula);
                var res = parser.Calculate();
            });
        }
        [Fact]
        public void Parentheses_NotValidChar_Formula()
        {
            //Parentheses
            Assert.Throws<FormulaParseException>(() =>
            {
                string formula = "((3556+78)/5 a)";
                FormulaParser parser = new(formula);
                var res = parser.Calculate();
            });
        }
        [Fact]
        public void Parentheses_NotValidNumber1_Formula()
        {
            //Parentheses
            Assert.Throws<FormulaParseException>(() =>
            {
                string formula = "((3556  +78  )  /  5      4)";
                FormulaParser parser = new(formula);
                var res = parser.Calculate();
            });
        }
        [Fact]
        public void Parentheses_NotValidNumber2_Formula()
        {
            //Parentheses
            Assert.Throws<FormulaParseException>(() =>
            {
                string formula = "((3  556  +78  )  /  5)";
                FormulaParser parser = new(formula);
                var res = parser.Calculate();
            });
        }

        [Fact]
        public void Parentheses_Real_Formula_Variable()
        {
            double x = 58.0;
            double xxx = 32.5;
            double y_x = 22.2;

            double number = x + 5.2 * xxx - 2.1 * (8.0 / 999.2) + ((y_x + 78.0) / 5.0);

            string formula = "x + 5.2 * xxx - 2.1 * (8.0 / 999.2) + ((y_x + 78.0) / 5.0)";
            FormulaParser parser = new(formula);
            parser.Variables["x"] = x;
            parser.Variables["xxx"] = xxx;
            parser.Variables["y_x"] = y_x;

            Assert.Equal(number, parser.Calculate());
        }

    }
}