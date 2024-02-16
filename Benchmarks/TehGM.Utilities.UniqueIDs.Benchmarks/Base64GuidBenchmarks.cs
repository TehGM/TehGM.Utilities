using BenchmarkDotNet.Attributes;

namespace TehGM.Utilities.UniqueIDs.Benchmarks
{
    [MemoryDiagnoser]
    [GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByJob)]
    public class Base64GuidBenchmarks
    {
        private Base64Guid _value;
        private string _guidDisplayValue;
        private string _trimmedDisplayValue;
        private string _untrimmedDisplayValue;

        [GlobalSetup]
        public void GlobalSetup()
        {
            this._value = Base64Guid.GenerateNew();
            this._guidDisplayValue = this._value.Value.ToString();
            this._trimmedDisplayValue = this._value.ToString();
            this._untrimmedDisplayValue = this._trimmedDisplayValue + "==";
        }

        [Benchmark]
        public void Base64Guid_Parse_FromGuid()
        {
            Base64Guid value = Base64Guid.Parse(this._guidDisplayValue);
        }

        [Benchmark]
        public void Base64Guid_Parse_FromTrimmedDisplayValue()
        {
            Base64Guid value = Base64Guid.Parse(this._trimmedDisplayValue);
        }

        [Benchmark]
        public void Base64Guid_Parse_FromUnrimmedDisplayValue()
        {
            Base64Guid value = Base64Guid.Parse(this._untrimmedDisplayValue);
        }

        [Benchmark]
        public void Base64Guid_ToString()
        {
            string value = this._value.ToString();
        }
    }
}
