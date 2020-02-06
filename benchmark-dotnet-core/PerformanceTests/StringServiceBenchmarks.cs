using BenchmarkDotNet.Attributes;

namespace benchmark_dotnet_core
{
    public class StringServiceBenchmarks
    {
        private readonly int _length = 10_000;
        private readonly string _text = "A";

        [Benchmark(Description = "Generate String by String")]
        public string GenerateStringByString()
        {
            IStringService service = new ForStringService();
            return service.Generate(_text, _length);
        }

        [Benchmark(Description = "Generate String by StringBuilder")]
        public string GenerateStringByBuilderService()
        {
            IStringService service = new StringBuilderService();
            return service.Generate(_text, _length);
        }
    }
}
