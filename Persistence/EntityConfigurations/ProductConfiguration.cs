using Common.Configurations;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

        builder.HasQueryFilter(x => !x.IsRemoved);

        builder.HasIndex(x => new { x.ManufactureEmail, x.ProduceDate }).IsUnique().HasFilter($"[{nameof(Product.IsRemoved)}] = 0");

        builder.Property(b => b.Name).IsRequired().HasMaxLength(FieldConfig.NameLength);
        builder.Property(b => b.ManufactureEmail).IsRequired().HasMaxLength(FieldConfig.EmailLength);
        builder.Property(b => b.ManufacturePhone).IsRequired().HasMaxLength(FieldConfig.PhoneLength);

        builder
            .HasOne(x => x.Creator)
            .WithMany()
            .HasForeignKey(x => x.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Updater)
            .WithMany()
            .HasForeignKey(x => x.UpdaterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}