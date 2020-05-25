using CommandLine;
using System;

namespace DevopsAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<ProgramOptions>(args)
                   .WithParsed<ProgramOptions>(o =>
                   {
                       if (string.IsNullOrEmpty(o.Path))
                       {
                           Console.Out.WriteLine("Empty Path");
                       }
                       if (o.CreationTime)
                       {
                           MergeRequestDataConverter.DeserializeFromURL(o.Path, o.URL);
                       }
                   });
        }
    }
}
