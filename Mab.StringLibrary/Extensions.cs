using System;
using System.Text;

namespace Mab.StringLibrary
{
    public static class Extensions
    {
        public static int Levenshtein(this string source, string target)
        {
            if (string.IsNullOrEmpty(source))
                return string.IsNullOrEmpty(target) ? 0 : target.Length;

            if (string.IsNullOrEmpty(target))
                return string.IsNullOrEmpty(source) ? 0 : source.Length;

            int sourceLength = source.Length;
            int targetLength = target.Length;

            int[,] distance = new int[sourceLength + 1, targetLength + 1];

            // Step 1
            for (int i = 0; i <= sourceLength; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetLength; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceLength; i++)
            {
                for (int j = 1; j <= targetLength; j++)
                {
                    // Step 2
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 3
                    distance[i, j] = Math.Min(
                                        Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                                        distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceLength, targetLength];


        }

        /// <summary>
        /// Compare string with target and return a number between 0 and 1 based on their similarity. 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target">String to compare</param>
        /// <returns></returns>
        public static double CalculateSimilarity(this string source, string target)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.IsNullOrEmpty(target) ? 1 : 0;
            }
            if (string.IsNullOrEmpty(target))
            {
                return string.IsNullOrEmpty(source) ? 1 : 0;
            }
            double stepsToSame = Levenshtein(source, target);
            return (1.0 - (stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
        /// <summary>
        /// Convert doublicate spaces to just one space
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveDoublicateSpaces(this string source)
        {
            if(string.IsNullOrEmpty( source))
            {
                return source;
            }
            StringBuilder result = new StringBuilder();
            bool foundSpace = false;
            foreach (var item in source)
            {
                if (item == Statics.SpaceChar && !foundSpace)
                {
                    foundSpace = true;
                    result.Append(item);
                }
                else if (item != Statics.SpaceChar)
                {
                    foundSpace = false;
                    result.Append(item);
                }
            }
            return result.ToString();
        }
    }
}
