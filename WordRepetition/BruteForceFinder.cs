using System;
using System.Collections.Generic;

namespace WordRepetition
{
    public class BruteForceFinder : IWordRepeatitionFinder
    {
        public HashSet<string> FindRepetition(String input)
        {
            var result = new HashSet<String>();
            if (String.IsNullOrEmpty(input) || input.Length == 1)
            {
                return result;
            }

            var pointerA = 0;

            while (pointerA < input.Length)
            {
                var pointerB = pointerA + 1;
                while (pointerB < input.Length)
                {
                    while (pointerB < input.Length && input[pointerB] != input[pointerA])
                    {
                        pointerB++;
                    }
                    if (pointerB < input.Length)
                    {
                        var length = pointerB - pointerA;
                        if (IsRepetition(input, pointerA, pointerB))
                        {

                            var repeatition = input.Substring(pointerA, length);
                            result.Add(repeatition);
                        }
                        pointerB += length;
                    }
                }
                pointerA++;
            }
            return result;
        }
        
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
