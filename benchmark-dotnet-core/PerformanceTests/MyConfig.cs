using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace benchmark_dotnet_core.PerformanceTests
{
    public class MyConfig : ManualConfig
    {
        public MyConfig()
        {
            // Add(CsvExporter.Default);

            Add(ConsoleLogger.Default);

            Add(HtmlExporter.Default);
            Add(MarkdownExporter.GitHub);
            Add(PlainExporter.Default);


            Add(TargetMethodColumn.Method);
            Add(StatisticColumn.Mean);
            Add(StatisticColumn.Median);
            Add(StatisticColumn.Min);
            Add(StatisticColumn.Max);
            Add(StatisticColumn.OperationsPerSecond);
            Add(RankColumn.Arabic);


            //Add(new MemoryDiagnoser());
            //Add(Job.Default
            //    .WithLaunchCount(1)
            //    .WithWarmupCount(0)
            //    .WithIterationCount(5)
            //);
        }
    }
}
