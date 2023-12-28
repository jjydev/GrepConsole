namespace GrepConsole.Parameters
{
    internal static class SearchParameterBuilder
    {
        internal static SearchParameter BuildParameter(string[] args)
        {
            bool reverse = false;
            if (args.Skip(1).Any(x => x.Equals("-v", StringComparison.OrdinalIgnoreCase)))
                reverse = true;

            bool caseInsensitive = false;
            if (args.Skip(1).Any(x => x.Equals("-i", StringComparison.OrdinalIgnoreCase)))
                caseInsensitive = true;

            var remainingArgs = args.Except(new[] { "grep", "-v", "-i" }, StringComparer.OrdinalIgnoreCase);
            if (!remainingArgs.Any())
                throw new ArgumentNullException(nameof(remainingArgs));

            var queryString = remainingArgs.First();

            return new SearchParameter(BuildInputSources(remainingArgs.Skip(1)).ToList(), 
                queryString, 
                reverse, 
                caseInsensitive);
        }

        // This can accept arguments or comma delimited string
        private static IEnumerable<IInputSource> BuildInputSources(IEnumerable<string> args)
        {
            foreach(var arg in args)
            {
                var inputs = arg.Split(",", StringSplitOptions.RemoveEmptyEntries);

                foreach(var input in inputs)
                {
                    var inputArgFormat = input.Split(":", StringSplitOptions.RemoveEmptyEntries);

                    var prefix = inputArgFormat.First();
                    var path = string.Join("", inputArgFormat.Skip(1));

                    if (File.Prefix == prefix)
                        yield return new File(path);
                    if (Folder.Prefix == prefix)
                        yield return new Folder(path);
                    if (Url.Prefix == prefix)
                        yield return new Url(path);
                }
            }
        }
    }
}