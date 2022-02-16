using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mab.StringLibrary
{
    public class StringCoder
    {
        private readonly char[] _usableChar;
        private readonly Dictionary<char,int> _charDictionary; //dictionary for fast decode from string to number
        private readonly int _base;

        /// <summary>
        /// Create a string coder based on char array
        /// </summary>
        /// <param name="usableChar"></param>
        public StringCoder(char[] usableChar)
        {
            _usableChar = usableChar;
            _base=_usableChar.Length;
            _charDictionary = new Dictionary<char, int>();
            FillDictionary();
        }

        /// <summary>
        /// Create a string coder with default base chars(latter and digits)
        /// </summary>
        public StringCoder()
        {
            _usableChar = Statics.GetAllLetterAndDigit();
            _base = _usableChar.Length;
            _charDictionary = new Dictionary<char, int>();
            FillDictionary();
        }
        private void FillDictionary()
        {
            for (int i = 0; i < _usableChar.Length; i++)
            {
                _charDictionary[_usableChar[i]] = i;
            }
        }

        /// <summary>
        /// Convert string to equivalent number.
        /// </summary>
        /// <param name="codedString">coded string to convert</param>
        /// <returns></returns>
        public long Decode(string codedString)
        {
            long result = 0;
            for (int i = 0; i < codedString.Length; i++)
            {
                result = result * _base + (_charDictionary[codedString[i]]);
            }
            return result;
        }

        /// <summary>
        /// Convert given number to equivalent string. 
        /// </summary>
        /// <param name="number">number to convert.</param>
        /// <returns></returns>
        public string Encode(long number)
        {
            StringBuilder codedString=new StringBuilder();
            long result=number;
            long remind;
            do
            {
                remind = result % _base;
                result = result / _base;
                codedString.Append(_usableChar[remind]);
            } while (result > 0);

            char[] codedArray= new char[codedString.Length];
            codedString.CopyTo(0, codedArray, 0, codedString.Length);
            Array.Reverse(codedArray);
            
            return new string(codedArray);
        }
    }
}
