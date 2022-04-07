using Mab.StringLibrary.Formula;
using Mab.StringLibrary.Formula.Exception;
using Xunit;

namespace Mab.StringLibrary.UnitTest
{
    public class FormulaParserTest
    {
        [Fact]
        public void One_Positive_Number()
        {
            decimal number = 58;

            FormulaParser parser = new(number.ToString());
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void One_Negative_Number()
        {
            decimal number = -58;

            FormulaParser parser = new(number.ToString());
            Assert.Equal(number, parser.Calculate());
        }

        [Fact]
        public void One_Negative_Real_Number()
        {
            decimal number = -58.545m;

            FormulaParser parser = new(number.ToString());
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void One_Positive_Real_Number()
        {
            decimal number = 58.545m;

            FormulaParser parser = new(number.ToString());
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void One_Explicit_Positive_Real_Number()
        {
            string number = "+58.545";

            FormulaParser parser = new(number);
            Assert.Equal(decimal.Parse(number), parser.Calculate());
        }

        [Fact]
        public void Simple_Formula()
        {
            //Parentheses
            decimal number = -4 + 5m * 2m - 2;
            string formula = "-4+5*2-2";
            FormulaParser parser = new(formula);
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void Simple_Real_Formula()
        {
            //Parentheses
            decimal number = -4.5m + 5.2m * 2m - 2.1m;
            string formula = "-4.5+5.2*2-2.1";
            FormulaParser parser = new(formula);
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void Parentheses_Real_Formula()
        {
            //Parentheses
            decimal number = -4.5m + 5.2m * 2m - 2.1m * (8m / 999.2m) + ((3556m + 78m) / 5m);
            string formula = "-4.5+5.2*2-2.1*(8/999.2)+((3556+78)/5)";
            FormulaParser parser = new(formula);
            Assert.Equal(number, parser.Calculate());
        }
        [Fact]
        public void Parentheses_Real_Number_Without_Zero_Decimal_Formula()
        {
            //Parentheses
            decimal number = -4.5m + .2m * 2m - 2.0m * (8m / 999.2m) + ((3556m + 78m) / 5m);
            string formula = "-4.5+.2*2-2.*(8/999.2)+((3556+78)/5)";
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
    }
}