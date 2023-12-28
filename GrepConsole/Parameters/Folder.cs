namespace GrepConsole.Parameters
{
    internal class Folder : File
    {
        public Folder(string path) : base(path) { }

        public static new string Prefix => "folder";
        public override IEnumerable<Content> GetContents()
        {
            // Iterate thru all files,
            // Then get contents
            return Directory.GetFiles(Path)
                .Select(x => new File(x))
                .SelectMany(x => x.GetContents());
        }
    }
}