using DapperDemo.Api.Repositories;

namespace DapperDemo.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDapperRepositories(this IServiceCollection services)
    {
        services.AddSingleton(serviceProvider =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ApplicationException("The connection string is null");
            return new SqlConnectionFactory(connectionString);
        });

        services.AddScoped<IPlayerRepository, UserDapperRepository>();
    }
}
