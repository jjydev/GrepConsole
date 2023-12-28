namespace GrepConsole.Parameters
{
    internal record SearchParameter(IEnumerable<IInputSource> Inputs,
        string QueryString,
        bool Reverse,
        bool CaseInsensitive
        );
}