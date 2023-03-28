using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagmentSystem.Infrastructure.DAL;

internal static class Extensions
{
    private const string SectionName = "database";
    
    public static IServiceCollection AddDatabase(this IServiceCollection services,IConfiguration configuration)
    {
        //const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=LibraryManagmentSystemDB;Trusted_Connection=True;";
        var section = configuration.GetSection(SectionName);
        services.Configure<DatabaseOptions>(section);
        var options = configuration.GetOptions<DatabaseOptions>(SectionName);
        
        
        services.AddDbContext<LibraryDbContext>(x => x.UseSqlServer(options.connectionString));
        services.AddHostedService<DatabaseInitializer>();
        
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