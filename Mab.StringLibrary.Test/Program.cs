
using Mab.StringLibrary;
using Mab.StringLibrary.Formula;
using System.Diagnostics;
using System.Text.RegularExpressions;

double y = -1 + 2 * -83 + -(-82 / -9) + +(8 * +2);

FormulaParser parser = new FormulaParser("(1+5-(5+4+(4-5/2)))");
string formated = parser.GetFormatedFormula();
Console.WriteLine(formated);
var result = parser.Calculate();


Console.WriteLine("Remove doublicate space: " + "this  is         text!".RemoveDuplicateSpaces());


RandomString randomString = new();



Console.WriteLine($"This is a random sentence: '{randomString.GetRandomSentence(180)}'");
Console.WriteLine();

Console.WriteLine($"This is a random string: '{randomString.GetRandomString(35)}'");
Console.WriteLine();

////(?<!\*)((?<!(^|\())\*)

////(?<![\*\/\+\-])((?<!(^|\())[\/\*\+\-])
//Regex regex = new Regex(@"(?<operator>(((?<!(^|\())(\/|\*|\+|\-))(?!\+)))");


StringCoder stringCoder = new StringCoder();
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