using System;
using System.Collections.Generic;

namespace WordRepetition
{
    public class MimicaRepeatitionFinder : IWordRepeatitionFinder
    {
        public HashSet<string> FindRepetition(string input)
        {
            var charIndexLookUp = CreateCharIndexLookUp(input);
            var result = new HashSet<string>();
            var charList = charIndexLookUp.Keys;
            foreach (var c in charList)
            {
                if (charIndexLookUp[c].Count > 1)
                {
                    result.UnionWith(FindRepeatitionOfChar(input, charIndexLookUp[c]));
                }
            }
            return result;
        }

        public HashSet<string> FindRepeatitionOfChar(string input, List<int> indexes)
        {
            var result = new HashSet<string>();
            for (var i = 0; i< indexes.Count - 1; i++)
            {
                var j = i + 1;
                while(j <= i + (indexes.Count - i)/2 )
                {
                    if (IsRepetition(input, indexes[i], indexes[j]))
                    {
                        var length = indexes[j] - indexes[i];
                        var repeatition = input.Substring(indexes[i], length);
                        result.Add(repeatition);
                    }
                    j++;
                }
            }
            return result;
        }

        public Dictionary<char, List<int>> CreateCharIndexLookUp(string input)
        {
            var lookUp = new Dictionary<char, List<int>>();
            for (var i=0; i<input.Length; i++)
            {
                var currChar = input[i];
                if (lookUp.ContainsKey(currChar))
                {
                    lookUp[currChar].Add(i);
                }
                else
                {
                    var newIndexList = new List<int>();
                    newIndexList.Add(i);
                    lookUp.Add(currChar, newIndexList);
                }
            }
            return lookUp;
        }
        
        /*
         * This method is same with the one in brute force class
         */
        public bool IsRepetition(String input, int pointerA, int pointerB)
        {
            var length = pointerB - pointerA - 1;
            
            if (pointerB + length >= input.Length)
            {
                return false;
            }

            for (var i = 1; i <= length; i++)
            {
                if (input[pointerA + i] != input[pointerB + i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
