using GrepConsole.Parameters;
using System.Text.RegularExpressions;

namespace GrepConsole.Strategy
{
    internal class ReverseCaseSensitiveSearchStrategy : ISearchStrategy
    {
        public IEnumerable<SearchResult> Search(IEnumerable<IInputSource> inputSource, string queryString)
        {
            var regex = new Regex(queryString);
            foreach (var input in inputSource)
            {
                foreach (var content in input.GetContents())
                {
                    if (!regex.IsMatch(content.Value))
                        yield return new SearchResult(content.Path, content.LineNumber, content.Value);
                }
            }
        }
    }
}