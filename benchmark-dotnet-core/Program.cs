using benchmark_dotnet_core.PerformanceTests;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace benchmark_dotnet_core
{
    class Program
    {
        static void Main(string[] args)
        {

            // dotnet run -c Release
            // var summary = BenchmarkRunner.Run<SingleVsFirstBenchmarks>();

            // var summary = BenchmarkRunner.Run<LinqBenchmarks>(new MyConfig());
            // var summary = BenchmarkRunner.Run<StringServiceBenchmarks>();

            // var summary = BenchmarkRunner.Run<TakeVsSliceBenchmarks>();

            var summary = BenchmarkRunner.Run<SystemTextVsJsonBenchmarks>();

        }
    }

    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class LinqBenchmarks
    {
        private readonly IEnumerable<int> numbers;

        [Params(10_000_000)]
        public int Size { get; set; }

        public LinqBenchmarks()
        {
            numbers = Enumerable.Range(1, Size).ToArray();
        }

        [Benchmark]
        public int[] GetAllWithThree()
        {
            return numbers.Where(x => x.ToString().Contains("3"))
            .ToArray();
        }

        [Benchmark]
        public int[] GetAllWithThreeParallel()
        {
            return numbers.AsParallel().Where(x => x.ToString()
            .Contains("3")).ToArray();
        }
    }
}
