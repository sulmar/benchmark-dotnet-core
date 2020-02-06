using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace benchmark_dotnet_core.PerformanceTests
{
    public class TakeVsSlice
    {
        private  readonly int _haystackSize = 100;

        private readonly int[] values;

         public TakeVsSlice()
        {
            values = Enumerable.Range(1, _haystackSize).ToArray();
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
