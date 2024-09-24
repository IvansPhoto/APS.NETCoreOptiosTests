using BenchmarkDotNet.Attributes;

namespace BenchMark;

[KeepBenchmarkFiles]
[MarkdownExporterAttribute.GitHub]
public class Runner
{
    private static readonly HttpClient HttpClient = new();
    private const string BaseUrlMonitor = "https://localhost:7149/monitor/text/";
    private const string BaseUrlSnapshot = "https://localhost:7149/snapshot/text/";

    [Benchmark]
    public async Task<string> Monitor1()
    {
        return await HttpClient.GetStringAsync(BaseUrlMonitor);
    }

    [Benchmark]
    public async Task<string> Snapshot1()
    {
        return await HttpClient.GetStringAsync(BaseUrlSnapshot);
    }

    [Benchmark]
    public async Task<string> Snapshot2()
    {
        return await HttpClient.GetStringAsync(BaseUrlSnapshot);
    }

    [Benchmark]
    public async Task<string> Monitor2()
    {
        return await HttpClient.GetStringAsync(BaseUrlMonitor);
    }
}