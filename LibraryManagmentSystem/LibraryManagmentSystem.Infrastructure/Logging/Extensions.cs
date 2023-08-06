using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace LibraryManagmentSystem.Infrastructure.Logging;

public static class Extensions
{
    public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            var logPath = "logs";
            var logFileName = "logs.txt";
            System.IO.Directory.CreateDirectory(logPath);

            var logFilePath = System.IO.Path.Combine(logPath, logFileName);

            configuration
                .MinimumLevel.Error()
                .WriteTo.File(logFilePath,
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Error,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
                );
        });

        return builder;
    }
}