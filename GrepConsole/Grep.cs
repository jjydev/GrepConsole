using GrepConsole.Parameters;
using GrepConsole.Strategy;

namespace GrepConsole
{
    internal interface ISearch
    {
        IEnumerable<SearchResult> Search(SearchParameter param);
    }

    internal class Grep : ISearch
    {
        public IEnumerable<SearchResult> Search(SearchParameter param)
        {
            var searchStrategy = SearchStrategyFactory.Create(new SearchStrategyParameter(param.Reverse, param.CaseInsensitive));
            return searchStrategy.Search(param.Inputs, param.QueryString).ToList();
        }
    }
}