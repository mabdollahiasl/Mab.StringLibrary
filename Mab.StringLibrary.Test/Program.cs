
using Mab.StringLibrary;
using Mab.StringLibrary.Formula;
using System.Diagnostics;
using System.Text.RegularExpressions;

string formula1 = "-12+47+7-(35+ 2 - -(21*2))";
double result1 = formula1.ParseAsFormula();


CustomFunction customFunction = (functionname, pars) =>
{
    if (functionname == "Avg")
        return pars.Average(); //using System.Linq
    else if (functionname == "Sum")
        return pars.Sum();
    else
        return 0;
};

string formula2 = "-12+7-Avg(35, 2 + Sum(5^2,-4))";
double result2 = formula2.ParseAsFormula(customFunction);

string formula3 = "-12+7-(35+ x*y)+Avg(5,8)";

Dictionary<string, double> vars = new() { { "x", 3 }, { "y", 4 } }; 

double result3 = formula3.ParseAsFormula(vars, customFunction);

Console.WriteLine("Expression Parser:");
Console.WriteLine($"{formula1} = {result1}");
Console.WriteLine($"{formula2} = {result2}");
Console.WriteLine($"{formula3} = {result3}");

Console.WriteLine();    

Console.WriteLine("Remove doublicate space: " + "this  is         text!".RemoveDuplicateSpaces());


RandomString randomString = new();



Console.WriteLine($"This is a random sentence: '{randomString.GetRandomSentence(180)}'");
Console.WriteLine();

Console.WriteLine($"This is a random string: '{randomString.GetRandomString(35)}'");
Console.WriteLine();

////(?<!\*)((?<!(^|\())\*)

////(?<![\*\/\+\-])((?<!(^|\())[\/\*\+\-])
//Regex regex = new Regex(@"(?<operator>(((?<!(^|\())(\/|\*|\+|\-))(?!\+)))");


StringCoder stringCoder = new();
long number = 54662144;
string enCode = stringCoder.Encode(number);

Console.WriteLine($"Coded value of '{number}' is '{enCode}'");

Console.WriteLine();
Console.WriteLine($"Decoded value of '{enCode}' is '{stringCoder.Decode("a3U1")}'");//214325


string big = randomString.GetRandomString(50);
string search = big[8..35];


var similarity = big.CalculateSimilarity(search);
Console.WriteLine($"Similarity between '{big}' and '{search}' is: {similarity:N2}");

similarity = "this is test".CalculateSimilarity("tihs is text");
Console.ReadKey();