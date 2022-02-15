using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary
{
    public class RandomString
    {

        private readonly Random _randomGenerator;
        public RandomString()
        {
            _randomGenerator = new Random();
        }
        public string GetRandomString(char start = Statics.DefaultStartChar,
                                      char end = Statics.DefaultEndChar,
                                      int len = 35)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < len - 1; i++)
            {
                char current = (char)_randomGenerator.Next(start, end + 1);
                builder.Append(current);
            }
            return builder.ToString();
        }

        public string GetRandomLengthString(char start = Statics.DefaultStartChar,
                                      char end = Statics.DefaultEndChar,
                                      int wordMinLen = Statics.DefaultStringMinLength,
                                      int wordMaxLen = Statics.DefaultStringMaxLength)
        {
            return GetRandomString(start, end, _randomGenerator.Next(wordMinLen, wordMaxLen));
        }

        public string GetRandomSentence(int sentenceLen,
                                        char start = Statics.DefaultStartChar,
                                        char end = Statics.DefaultEndChar,
                                        int wordMinLen = Statics.DefaultStringMinLength,
                                        int wordMaxLen = Statics.DefaultStringMaxLength)
        {
            StringBuilder builder = new StringBuilder();
            while (builder.Length < sentenceLen)
            {
                string curWord = GetRandomString(start, end, _randomGenerator.Next(wordMinLen, wordMaxLen));
                builder.Append(curWord);
                builder.Append(Statics.SpaceChar);
            }

            return builder.ToString()[..sentenceLen];
        }
    }
}
