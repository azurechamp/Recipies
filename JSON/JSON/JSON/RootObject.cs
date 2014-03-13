using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    public class Result
    {
        public string title { get; set; }
        public string href { get; set; }
        public string ingredients { get; set; }
        public string thumbnail { get; set; }
    }

    public class RootObject
    {
        public string title { get; set; }
        public double version { get; set; }
        public string href { get; set; }
        public List<Result> results { get; set; }
    }
}