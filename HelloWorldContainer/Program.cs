using Serilog;
using Serilog.Sinks.Grafana.Loki;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

// Configure Serilog early so framework logs go through it.
// Read from configuration but ensure Console sink and Verbose level.
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    //.WriteTo.GrafanaLoki("http://localhost:3100")
    .CreateLogger();

builder.Host.UseSerilog();

builder.AddServiceDefaults();
// Add services to the container.
builder.Services.AddControllers();

// Swagger / OpenAPI (Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    // Swashbuckle JSON path
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Container test api v1");
    // Serve UI at /swagger to match launchSettings
    options.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
