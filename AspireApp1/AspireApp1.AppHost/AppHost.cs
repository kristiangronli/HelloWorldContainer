var builder = DistributedApplication.CreateBuilder(args);

var grafana = builder.AddContainer("grafana", "grafana/otel-lgtm:latest")
    .WithEndpoint(port: 4318, targetPort: 4318, name: "otlp-http", scheme: "http", isProxied: true, isExternal: true)
    .WithEndpoint(port: 3100, targetPort: 3100, name: "loki", scheme: "http", isProxied: true, isExternal: true)
    .WithEndpoint(port: 3000, targetPort: 3000, name: "ui", scheme: "http", isProxied: true, isExternal: true);
    //.WithEndpoint(port: 4317, targetPort: 4317, name: "otlp-grpc", scheme: "http", isProxied: true, isExternal: true)


builder.AddProject<Projects.HelloWorldContainer>("helloworldcontainer")
    .WaitFor(grafana);

builder.Build().Run();
