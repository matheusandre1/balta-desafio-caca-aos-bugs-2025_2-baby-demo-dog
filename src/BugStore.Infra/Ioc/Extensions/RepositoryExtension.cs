using BugStore.Domain.Base;
using BugStore.Infra.CompiledModels;
using BugStore.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BugStore.Infra.IoC;

public static class InfraServiceCollectionExtensions
{
    public static IServiceCollection AddInfraPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default") ?? "Data Source=bugstore.db";

        services.AddDbContext<AppContextDb>(options =>
        {
            options.UseSqlite(connectionString);
            options.UseModel(AppContextDbModel.Instance);
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}