using LibraryManagmentSystem.Domain.Interfaces;
using LibraryManagmentSystem.Infrastructure.DAL;
using LibraryManagmentSystem.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagmentSystem.Infrastructure;

public static class Extensions
{
    private const string SectionName = "database";
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddScoped<IReservationsRepository,ReservationsRepository>();
        services.AddScoped<IUserRepository,UserRepository>();
        services.AddScoped<IPublishedHouseRepository,PublishedHouseRepository>();
        return services;
    }
    
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}