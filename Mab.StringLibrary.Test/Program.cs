
using Mab.StringLibrary;


RandomString randomString = new();



Console.WriteLine($"This is a random sentence: {randomString.GetRandomSentence(180)}");
Console.WriteLine();

Console.WriteLine($"This is a random string: {randomString.GetRandomString(35)}");
Console.WriteLine();




StringCoder stringCoder = new StringCoder();
long number = 54662144;
string enCode = stringCoder.Encode(number);

Console.WriteLine($"Coded value of {number} is {enCode}");

Console.WriteLine();
Console.WriteLine($"Decoded value of {enCode} is {stringCoder.Decode(enCode)}");



Console.ReadKey();