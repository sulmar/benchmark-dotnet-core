using System;
using System.Collections.Generic;
using System.Text;

namespace benchmark_dotnet_core
{


    public interface IStringService
    {
        string Generate(string text, int length);
    }

    public class ForStringService : IStringService
    {
        public string Generate(string text, int length)
        {
            string result = "";

            for (int i = 0; i < length; i++)
            {
                result += text;
            }
            return result;
        }
    }

    public class StringBuilderService : IStringService
    {
        public string Generate(string text, int length)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(text);
            }
            return result.ToString();
        }
    }
}
