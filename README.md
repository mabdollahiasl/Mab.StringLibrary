

## Mab.StringLibrary

The library add some functionality to .net string class.

[![NuGet version](https://badge.fury.io/nu/Mab.StringLibrary.svg)](https://badge.fury.io/nu/Mab.StringLibrary)

## Formula or Expression Parser:
some extension string function to parse any formula or expression:
some example formula:

> -12+7-(35+ 2 - -(21*2))

> -12+7-Avg(35, 2 + Sum(5^2,-4))
> Avg and Sum are custom user functions

> -12+7-(35+ x*y)+Avg(5,8)
> x and y are variable and Avg is user custom function

**Sample Code to parse expression:**

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


## RandomString Class:

It generates random string based on given characters.  

**Sample code:**

    RandomString randomString = new RandomString();
    
    //generate a sentence with the length of 180 
    var rendomSentence = randomString.GetRandomSentence(180);
    
    //generate random word with the length of 35:
    var randomWord=randomString.GetRandomString(35);

## StringCoder Class:

It's encode and decode string to long and vise versa.
Main usage of this class is to make shorten URLs.
the Class has the option to change the character list for decode and encode.
 
 **Sample Code:**

    long number = 54662144;
    string enCode = stringCoder.Encode(number);
    //enCode is set to: 'dRwhE'
    long deCode=stringCoder.Decode("a3U1");
    //deCode is set to 214325

## CalculateSimilarity extension function:

It compares a string with target and return a number between 0 and 1 based on their similarity. 

**Sample Code:**

    string result="this is test";
    double similarity=result.CalculateSimilarity("tihs is text");
    //similarity is set to 0.75

## Remove duplicate space extension function:
Convert duplicate space to one space: 

    Console.WriteLine("Remove duplicate space: " + "this  is         text!".RemoveDuplicateSpaces());


