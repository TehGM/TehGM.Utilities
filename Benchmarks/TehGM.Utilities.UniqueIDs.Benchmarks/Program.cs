using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace TehGM.Utilities.UniqueIDs.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManualConfig config = ManualConfig.CreateMinimumViable()
                .AddJob(Job.Default
                    .AsBaseline()
                    .WithRuntime(CoreRuntime.Core60)
                    .WithPlatform(Platform.X64)
                    .WithGcServer(true))
                .AddJob(Job.Default
                    .AsBaseline()
                    .WithRuntime(CoreRuntime.Core80)
                    .WithPlatform(Platform.X64)
                    .WithGcServer(true))
                .WithOptions(ConfigOptions.DisableLogFile)
                .WithOptions(ConfigOptions.DisableOptimizationsValidator);

            BenchmarkRunner.Run(typeof(Program).Assembly, config, args);
        }
    }
}
