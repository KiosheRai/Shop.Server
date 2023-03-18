using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;

namespace Shop.Persistence.EntityTypeConfigurations;

public class BookConfiguration
    : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(entity => entity.Id);
        builder.HasIndex(entity => entity.Id).IsUnique();
        builder.Property(entity => entity.Name).HasMaxLength(255);
        builder.Property(entity => entity.Description).HasMaxLength(255);
    }
}