using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class ProductBrandConfiguration : BaseEntityConfiguration<ProductBrand>
{
    public override void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name)
            .HasMaxLength(200);
    }
}