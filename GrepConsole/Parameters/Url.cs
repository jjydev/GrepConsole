using System.Net;

namespace GrepConsole.Parameters
{
    internal class Url : IInputSource
    {
        public static string Prefix => "url";
        public string Path { get; }

        public Url(string path)
        {
            Path = path;
        }

        public IEnumerable<Content> GetContents()
        {
            var wc = new WebClient();
            var webData = wc.DownloadString(Path);
            return webData.Split("\r\n")
                .Select((x, i) => new Content(i+1, x, Path))
                .ToList();
        }
    }
}