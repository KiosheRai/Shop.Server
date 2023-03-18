namespace Shop.Persistence;

public static class DbInitializer
{
    public static void Initialize(ShopDbContext context)
    {
        context.Database.EnsureCreated();
    }
}