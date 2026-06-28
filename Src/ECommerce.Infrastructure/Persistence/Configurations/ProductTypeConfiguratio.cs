using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class ProductTypeConfiguration : BaseEntityConfiguration<ProductType>
{
    public override void Configure(EntityTypeBuilder<ProductType> builder)
    {
        base.Configure(builder);

    

        builder.Property(x => x.Name)
            .HasMaxLength(200);
    }
}