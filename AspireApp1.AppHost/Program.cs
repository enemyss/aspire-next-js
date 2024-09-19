using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Api>("api");

var frontend = builder
    .AddNpmApp(
        "frontend",
        "../frontend",
        "dev"
    )
    .WithEnvironment("NODE_ENV", "development")
    .WithReference(api)
    .WithOtlpExporter()
    .WithHttpEndpoint(env: "PORT", port: 3000)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();
    ;

var launchProfile = builder.Configuration["DOTNET_LAUNCH_PROFILE"] ??
    builder.Configuration["AppHost:DefaultLaunchProfileName"];
if (builder.Environment.IsDevelopment() && launchProfile == "https")
{
    // Disable TLS certificate validation in development, see https://github.com/dotnet/aspire/issues/3324 for more details.
    frontend.WithEnvironment("NODE_TLS_REJECT_UNAUTHORIZED", "0");
}

builder.Build().Run();
