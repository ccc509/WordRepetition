using System.Collections.Generic;

namespace WordRepetition
{
    public interface IWordRepetitionFinder
    {
        HashSet<string> FindRepetition(string input);
    }
}
