using Kondor.Domain.Repositories;
using Kondor.Infrastructure.Persistence;
using Kondor.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kondor.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<KondorDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IConnectionRepository, ConnectionRepository>();

        return services;
    }
}