using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace benchmark_dotnet_core.PerformanceTests
{
    public class SingleVsFirst
    {
        private readonly IList<string> _haystack = new List<string>();
        private readonly int _haystackSize = 1000000;
        private readonly string _needle = "needle";

        public SingleVsFirst()
        {
            //Add a large amount of items to our list. 
            Enumerable.Range(1, _haystackSize).ToList().ForEach(x => _haystack.Add(x.ToString()));
            //Insert the needle right in the middle. 
            _haystack.Insert(_haystackSize / 2, _needle);
        }

        [Benchmark]
        public string Single() => _haystack.SingleOrDefault(x => x == _needle);

        [Benchmark]
        public string First() => _haystack.FirstOrDefault(x => x == _needle);

    }
}