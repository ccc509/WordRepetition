using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WordRepetition
{
    public class MimicaRepetitionFinder : IWordRepetitionFinder
    {
        private string _input;
        private Dictionary<Tuple<int, int>, string> _subStringPositionLookUp;

        public HashSet<string> FindRepetition(string input)
        {
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            stopWatch.Start();
            _subStringPositionLookUp = new Dictionary<Tuple<int, int>, string>();
            var charIndexLookUp = CreateCharIndexLookUp(input);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("First half " + ts.TotalMilliseconds);
            stopWatch.Reset();
            stopWatch.Start();
            var result = new HashSet<string>();
            var charList = charIndexLookUp.Keys;
            foreach (var c in charList)
            {
                if (charIndexLookUp[c].Count > 1)
                {
                    result.UnionWith(FindRepetitionOfChar(input, charIndexLookUp[c]));
                }
            }

            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("Second half " + ts.TotalMilliseconds);

            return result;
        }

        public HashSet<string> FindRepetitionOfChar(string input, List<int> indexes)
        {
            _input = input;
            var result = new HashSet<string>();
            for (var i = 0; i< indexes.Count - 1; i++)
            {
                
                var j = i + 1;
                while(j <= i + (indexes.Count - i)/2 )
                {
                    var repeatition = GetRepetition(indexes[i], indexes[j]);
                    if (repeatition != null)
                    {   
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
        
        public string GetRepetition(int pointerA, int pointerB)
        {
            var length = pointerB - pointerA;
            
            if (pointerB + length > _input.Length)
            {
                return null;
            }
            
            var subStringA = GetSubString(pointerA,length);
            var subStringB = GetSubString(pointerB, length);

            if (subStringA.Equals(subStringB))
            {
                return subStringA;
            }
            return null;
        }

        private string GetSubString(int startingPosition, int length)
        {
            var key = new Tuple<int, int>(startingPosition, length);
            if (_subStringPositionLookUp.ContainsKey(key))
            {
                return _subStringPositionLookUp[key];
            }
            else
            {
                var subString = _input.Substring(startingPosition, length);
                _subStringPositionLookUp.Add(key,subString);
                return subString;
            }
        }
    }
}
