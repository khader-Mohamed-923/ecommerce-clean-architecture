

namespace ECommerce.Infrastructure.Persistence.Seeders;

public interface ISeeder
{
    Task SeedAsync(CancellationToken cancellationToken = default);
}
