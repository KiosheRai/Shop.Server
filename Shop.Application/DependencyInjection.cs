using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Books;
using Shop.Application.Orders;

namespace Shop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<BooksManager>();
        services.AddTransient<OrdersManager>();
        return services;
    }
}