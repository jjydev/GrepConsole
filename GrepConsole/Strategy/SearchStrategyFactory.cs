namespace GrepConsole.Strategy
{
    internal static class SearchStrategyFactory
    {
        internal static ISearchStrategy Create(SearchStrategyParameter param)
        {
            ArgumentNullException.ThrowIfNull(param, nameof(param));

            if (!param.Reverse && param.CaseInsensitive)
                return new RegularCaseInsensitiveSearchStrategy();
            if (!param.Reverse && !param.CaseInsensitive)
                return new RegularCaseSensitiveSearchStrategy();
            if (param.Reverse && param.CaseInsensitive)
                return new ReverseCaseInsensitiveSearchStrategy();
            if (param.Reverse && !param.CaseInsensitive)
                return new ReverseCaseSensitiveSearchStrategy();

            throw new NotSupportedException();
        }
    }
}