using GrepConsole.Parameters;

namespace GrepConsole.Strategy
{
    internal interface ISearchStrategy
    {
        IEnumerable<SearchResult> Search(IEnumerable<IInputSource> inputSource, string queryString);
    }
}