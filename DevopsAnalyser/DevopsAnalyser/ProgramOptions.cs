using CommandLine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DevopsAnalyser
{
    class ProgramOptions
    {
        [Value(0)]
        public string Path { get; set; }

        [Option('c', "CreationTime")]
        public bool CreationTime { get; set; }

        [Option('u', "url")]
        public bool URL { get; set; }

        [Option('f', "file")]
        public bool File { get; set; }
    }
}
