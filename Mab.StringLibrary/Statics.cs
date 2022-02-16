using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mab.StringLibrary
{
    public static class Statics
    {
        public const string Space = " ";
        public const char SpaceChar = ' ';
        public const int DefaultStringMinLength = 4;
        public const int DefaultStringMaxLength = 16;
        
        public const char FirstLowerCase = 'a';
        public const char FirstUpperCase = 'A';
        public const char FirstDigit = '0';
        
        public const char LastUpperCase = 'Z';
        public const char LastLowerCase = 'z';
        public const char LastDigit = '9';


        public static char[] GetCharRange(char start,char end, params char[]? exceptions)
        {
            List<char> result = new List<char>();
            for (char curChar = start; curChar <= end; curChar++)
            {
                if(exceptions==null || !exceptions.Contains(curChar))
                {
                    result.Add(curChar);
                }
            }
            return result.ToArray();
        }

        public static char[] GetCharRange(char start, char end)
        {
            return GetCharRange(start, end, null);
        }
        public static char[] GetAllLowerCase()
        {
            return GetCharRange(FirstLowerCase, LastLowerCase);
        }
        public static char[] GetAllUpperCase()
        {
            return GetCharRange(FirstUpperCase, LastUpperCase);
        }
        public static char[] GetAllDigit()
        {
            return GetCharRange(FirstDigit, LastDigit);
        }
        public static char[] GetAllLetter()
        {
            List<char> result=new List<char>();
            result.AddRange(GetAllLowerCase());
            result.AddRange(GetAllUpperCase());
            return result.ToArray();
        }
        public static char[] GetAllLetterAndDigit()
        {
            List<char> result = new List<char>();
            result.AddRange(GetAllLowerCase());
            result.AddRange(GetAllUpperCase());
            result.AddRange(GetAllDigit());
            return result.ToArray();
        }

    }
}
