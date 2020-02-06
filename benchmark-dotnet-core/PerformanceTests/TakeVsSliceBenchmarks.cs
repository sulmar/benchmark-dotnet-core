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
    public class TakeVsSliceBenchmarks
    {
        [Params(1_000_000)]
        public int Size { get; set; }

        private int[] values;

        [GlobalSetup]
        public void Setup()
        {
            values = Enumerable.Range(1, Size).ToArray();
        }

        [Benchmark]
        public void Take()
        {
            var a = values.Skip(5);
        }

        [Benchmark]
        public void Slice()
        {
            var span = new Span<int>(values, 0, values.Length);
            var a = span.Slice(5, span.Length - 5);
        }
    }
}
