using System.Collections.Generic;

namespace WordRepetition
{
    public interface IWordRepeatitionFinder
    {
        HashSet<string> FindRepetition(string input);
    }
}
