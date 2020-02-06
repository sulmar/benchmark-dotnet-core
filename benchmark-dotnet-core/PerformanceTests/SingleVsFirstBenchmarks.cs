using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace benchmark_dotnet_core.PerformanceTests
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class SingleVsFirstBenchmarks
    {
        private readonly IList<string> _haystack = new List<string>();

        [Params(1_000_000)]
        public int HaystackSize { get; set; }

        private string _needle = "needle";

        [GlobalSetup]
        public void Setup()
        {
            //Add a large amount of items to our list. 
            Enumerable.Range(1, HaystackSize).ToList().ForEach(x => _haystack.Add(x.ToString()));
            //Insert the needle right in the middle. 
            _haystack.Insert(HaystackSize / 2, _needle);
        }

        [Benchmark]
        public string Single() => _haystack.SingleOrDefault(x => x == _needle);

        [Benchmark]
        public string First() => _haystack.FirstOrDefault(x => x == _needle);

    }
}