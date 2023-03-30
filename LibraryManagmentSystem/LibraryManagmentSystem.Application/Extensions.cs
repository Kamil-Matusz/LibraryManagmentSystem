using LibraryManagmentSystem.Application.Mapping;
using LibraryManagmentSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagmentSystem.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBooksService, BooksService>();
        services.AddAutoMapper(typeof(BookMappingProfile));
        return services;
    }
}