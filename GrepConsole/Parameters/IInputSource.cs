namespace GrepConsole.Parameters
{
    internal interface IInputSource
    {
        string Path { get;}

        IEnumerable<Content> GetContents();
    }
}