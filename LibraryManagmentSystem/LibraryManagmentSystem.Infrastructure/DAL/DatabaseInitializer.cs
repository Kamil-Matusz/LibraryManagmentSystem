﻿using LibraryManagmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryManagmentSystem.Infrastructure.DAL;

internal  sealed class DatabaseInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
            dbContext.Database.Migrate();

            var status = dbContext.Status.ToList();
            if (!status.Any())
            {
                status = new List<Status>()
                {
                    new Status(1, "Gotowa do odbioru"),
                    new Status(2, "Wypożyczona"),
                    new Status(3, "Oddana"),
                };
                dbContext.Status.AddRange(status);
                dbContext.SaveChanges();
            }
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}