using System;
using System.Collections.Generic;
using System.Text;

namespace Mab.StringLibrary
{
    public class RandomString
    {
        private readonly char[] _usableChar;
        private readonly Random _randomGenerator;


        /// <summary>
        /// Create a string random maker and just use the given chars to make random strings.
        /// </summary>
        /// <param name="usableChar">Char array to use for making random strings.</param>
        public RandomString(char[] usableChar)
        {
            _usableChar = usableChar;
            _randomGenerator = new Random();
        }
        /// <summary>
        /// Create a string random maker and use lowercase latters to make random strings.
        /// </summary>
        public RandomString()
        {
            _usableChar= Statics.GetAllLowerCase();
            _randomGenerator= new Random();
        } 

        /// <summary>
        /// Get a random string.
        /// </summary>
        /// <param name="len">The length of output string</param>
        /// <returns></returns>
        public string GetRandomString(int len = 35)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < len - 1; i++)
            {
                char current =_usableChar[_randomGenerator.Next(0, _usableChar.Length)];
                builder.Append(current);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Get a random length string by given the length range.
        /// </summary>
        /// <param name="wordMinLen">Minimum length of string.</param>
        /// <param name="wordMaxLen">Maximum length of string.</param>
        /// <returns></returns>
        public string GetRandomLengthString(int wordMinLen = Statics.DefaultStringMinLength,
                                            int wordMaxLen = Statics.DefaultStringMaxLength)
        {
            return GetRandomString(_randomGenerator.Next(wordMinLen, wordMaxLen));
        }

        /// <summary>
        /// Get a random sentence.
        /// </summary>
        /// <param name="sentenceLen">Output sentence length</param>
        /// <param name="wordMinLen">Minimum length of word in the output sentence</param>
        /// <param name="wordMaxLen">Maximum length of word in the output sentence</param>
        /// <returns></returns>
        public string GetRandomSentence(int sentenceLen,
                                        int wordMinLen = Statics.DefaultStringMinLength,
                                        int wordMaxLen = Statics.DefaultStringMaxLength)
        {
            StringBuilder builder = new StringBuilder();
            while (builder.Length < sentenceLen)
            {
                string curWord = GetRandomString(_randomGenerator.Next(wordMinLen, wordMaxLen));
                builder.Append(curWord);
                builder.Append(Statics.SpaceChar);
            }

            return builder.ToString()[..sentenceLen];
        }
    }
}
