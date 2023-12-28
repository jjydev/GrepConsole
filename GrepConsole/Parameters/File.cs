namespace GrepConsole.Parameters
{

    internal class File : IInputSource
    {
        public string Path { get; }

        public File(string path)
        {
            Path = path;
        }

        public static string Prefix => "file";

        public virtual IEnumerable<Content> GetContents()
        {
            return System.IO.File.ReadAllLines(Path)
                .Select((x, i) => new Content(i+1, x, Path))
                .ToList();
        }
    }
}