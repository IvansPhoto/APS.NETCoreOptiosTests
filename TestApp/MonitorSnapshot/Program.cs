using MonitorSnapshot;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<Cfg>()
    .Bind(builder.Configuration.GetSection(Cfg.Section))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddTransient<IOptionSnapshotService1, OptionSnapshotService1>();
builder.Services.AddTransient<IOptionSnapshotService2, OptionSnapshotService2>();
builder.Services.AddTransient<IOptionSnapshotService3, OptionSnapshotService3>();

builder.Services.AddTransient<IOptionMonitorService1, OptionMonitorService1>();
builder.Services.AddTransient<IOptionMonitorService2, OptionMonitorService2>();
builder.Services.AddTransient<IOptionMonitorService3, OptionMonitorService3>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/monitor/{id}", async (IOptionMonitorService1 service, string id) =>
    {
        var result = await service.Do(id);
        return Results.Ok(new Response(result, result.Length));
    })
    .WithName("monitor")
    .WithOpenApi();

app.MapGet("/snapshot/{id}", async (IOptionSnapshotService1 service, string id) =>
    {
        var result = await service.Do(id);
        return Results.Ok(new Response(result, result.Length));
    })
    .WithName("snapshot")
    .WithOpenApi();


app.Run();
