using benchmark_dotnet_core.PerformanceTests;
using BenchmarkDotNet.Attributes;
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
            // var summary = BenchmarkRunner.Run<SingleVsFirst>();

            // var summary = BenchmarkRunner.Run<LinqBenchmark>(new MyConfig());
           // var summary = BenchmarkRunner.Run<StringServiceBenchmarks>();
           
            var summary = BenchmarkRunner.Run<TakeVsSlice>();

        }
    }

    public class LinqBenchmark
    {
        public readonly IEnumerable<int> numbers;

        public LinqBenchmark()
        {
            numbers = Enumerable.Range(1, 10000000).ToArray();
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
