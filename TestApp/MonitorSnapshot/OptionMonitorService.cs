using Microsoft.Extensions.Options;

namespace MonitorSnapshot;

public interface IOptionMonitorService1
{
    Task<string> Do(string input);
}

public sealed class OptionMonitorService1 : IOptionMonitorService1
{
    private readonly ILogger<OptionMonitorService1> _logger;
    private readonly IOptionsMonitor<Cfg> _options;
    private readonly IOptionMonitorService2 _service2;

    public OptionMonitorService1(ILogger<OptionMonitorService1> logger, IOptionsMonitor<Cfg> options, IOptionMonitorService2 service2)
    {
        _logger = logger;
        _options = options;
        _service2 = service2;
    }

    public async Task<string> Do(string input)
    {
        _logger.LogInformation("Doing in {ServiceName}", nameof(OptionMonitorService1));
        
        var currentValue = _options.CurrentValue.FirstStr;
        var data = $"{input}-{currentValue}";
        
        await Task.Delay(10);
        
        var result = await _service2.Do(data);
        return new string(result.Reverse().ToArray());
    }
}

public interface IOptionMonitorService2
{
    Task<string> Do(string input);
}

public sealed class OptionMonitorService2 : IOptionMonitorService2
{
    private readonly ILogger<OptionMonitorService2> _logger;
    private readonly IOptionsMonitor<Cfg> _options;
    private readonly IOptionMonitorService3 _service3;

    public OptionMonitorService2(ILogger<OptionMonitorService2> logger, IOptionsMonitor<Cfg> options, IOptionMonitorService3 service3)
    {
        _logger = logger;
        _options = options;
        _service3 = service3;
    }

    public async Task<string> Do(string input)
    {
        var data = $"{input}-{_options.CurrentValue.SecondStr}";
        _logger.LogInformation("Doing in {ServiceName}", nameof(OptionMonitorService2));
        var result = await _service3.Do(data);
        return new string(result.Reverse().ToArray());
    }
}

public interface IOptionMonitorService3
{
    Task<string> Do(string input);
}

public sealed class OptionMonitorService3 : IOptionMonitorService3
{
    private readonly ILogger<OptionMonitorService3> _logger;
    private readonly IOptionsMonitor<Cfg> _options;

    public OptionMonitorService3(ILogger<OptionMonitorService3> logger, IOptionsMonitor<Cfg> options)
    {
        _logger = logger;
        _options = options;
    }

    public async Task<string> Do(string input)
    {
        var result = $"{input}-{_options.CurrentValue.Number}";
        await Task.Delay(10);
        _logger.LogInformation("Doing in {ServiceName}", nameof(OptionMonitorService3));
        return new string(result.Reverse().ToArray());
    }
}