using ConsoleApp;
using ConsoleApp.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Abstractions;
using Services.Implementations;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<StartUp>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ITextService, TextService>();
builder.Services.AddLogging(loggerBuilder =>
{
    loggerBuilder.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
});

using IHost host = builder.Build();

await host.RunAsync();
