using GrepConsole.Parameters;
using System.Linq;

namespace GrepConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValidateCommand(args);

            // sample : grep –v –i ping file:file.txt
            // sample : grep –v –i hello file:file.txt,url:http://www.lipsum.com/,folder:C:\Projects\Test
            var parameter = SearchParameterBuilder.BuildParameter(args);

            var results = new Grep().Search(parameter);

            if (!results.Any())
                Console.WriteLine("No results");
            
            foreach(var result in results)
                Console.WriteLine($"{result.InputSource} | line{result.LineNumber} = {result.Match}");

            Console.ReadKey();
        }

        private static void ValidateCommand(string[] args)
        {
            if (args.Length == 0 || !string.Equals(args[0], "grep", StringComparison.OrdinalIgnoreCase))
                throw new NotSupportedException();
        }
    }
}