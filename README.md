## Mab.StringLibrary

The library add some functionality to .net string class.

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
