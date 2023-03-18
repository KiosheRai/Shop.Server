using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;

namespace Shop.Persistence.EntityTypeConfigurations;

public class OrderConfiguration
        : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.HasIndex(entity => entity.Id).IsUnique();
    }
}