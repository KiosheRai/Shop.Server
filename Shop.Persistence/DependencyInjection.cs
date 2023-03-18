using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces;

namespace Shop.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AppPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<ShopDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IShopDbContext>(provider =>
            provider.GetService<IShopDbContext>()!);

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}