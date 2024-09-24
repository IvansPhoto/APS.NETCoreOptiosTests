using Microsoft.Extensions.Options;

namespace MonitorSnapshot;

public interface IOptionSnapshotService1
{
    Task<string> Do(string input);
}

public sealed class OptionSnapshotService1 : IOptionSnapshotService1
{
    private readonly ILogger<OptionSnapshotService1> _logger;
    private readonly IOptionsSnapshot<Cfg> _options;
    private readonly IOptionSnapshotService2 _service2;

    public OptionSnapshotService1(ILogger<OptionSnapshotService1> logger, IOptionsSnapshot<Cfg> options, IOptionSnapshotService2 service2)
    {
        _logger = logger;
        _options = options;
        _service2 = service2;
    }

    public async Task<string> Do(string input)
    {
        var data = $"{input}-{_options.Value.FirstStr}";
        await Task.Delay(10);
        _logger.LogInformation("Doing in {ServiceName}", nameof(OptionSnapshotService1));
        var result = await _service2.Do(data);
        return new string(result.Reverse().ToArray());
    }
}

public interface IOptionSnapshotService2
{
    Task<string> Do(string input);
}

public sealed class OptionSnapshotService2 : IOptionSnapshotService2
{
    private readonly ILogger<OptionSnapshotService2> _logger;
    private readonly IOptionsSnapshot<Cfg> _options;
    private readonly IOptionSnapshotService3 _service3;

    public OptionSnapshotService2(ILogger<OptionSnapshotService2> logger, IOptionsSnapshot<Cfg> options, IOptionSnapshotService3 service3)
    {
        _logger = logger;
        _options = options;
        _service3 = service3;
    }

    public async Task<string> Do(string input)
    {
        var data = $"{input}-{_options.Value.SecondStr}";
        _logger.LogInformation("Doing in {ServiceName}", nameof(OptionSnapshotService2));
        var result = await _service3.Do(data);
        return new string(result.Reverse().ToArray());
    }
}

public interface IOptionSnapshotService3
{
    Task<string> Do(string input);
}

public sealed class OptionSnapshotService3 : IOptionSnapshotService3
{
    private readonly ILogger<OptionSnapshotService3> _logger;
    private readonly IOptionsSnapshot<Cfg> _options;

    public OptionSnapshotService3(ILogger<OptionSnapshotService3> logger, IOptionsSnapshot<Cfg> options)
    {
        _logger = logger;
        _options = options;
    }

    public async Task<string> Do(string input)
    {
        var result = $"{input}-{_options.Value.Number}";
        await Task.Delay(10);
        _logger.LogInformation("Doing in {ServiceName}", nameof(OptionSnapshotService3));
        return new string(result.Reverse().ToArray());
    }
}