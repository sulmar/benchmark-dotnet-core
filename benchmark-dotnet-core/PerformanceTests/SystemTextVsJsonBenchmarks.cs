using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace benchmark_dotnet_core.PerformanceTests
{
    //https://dotnetcoretutorials.com/2020/01/25/what-those-benchmarks-of-system-text-json-dont-mention/
    public class MyClass
    {
        public int MyInteger { get; set; }

        public string MyString { get; set; }

        public List<string> MyList { get; set; }
    }

    public class SystemTextVsJsonBenchmarks
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        private const string _jsonStringCamelCase = "{\"myString\" : \"abc\", \"myInteger\" : 123, \"myList\" : [\"abc\", \"123\"]}";

        [Benchmark]
        public MyClass SystemTextCaseInsensitive_Camel()
        {
            return JsonSerializer.Deserialize<MyClass>(_jsonStringCamelCase, options);
        }

        [Benchmark]
        public MyClass NewtonSoftJson_Camel()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<MyClass>(_jsonStringCamelCase);
        }
    }
}
