using ECommerce.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECommerce.Infrastructure.Persistence.Seeders;

public class SeederCoordinator(
    IEnumerable<ISeeder> seeders,
    StoreDbContext context,
    ILogger<SeederCoordinator> logger)
{
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        await using var transaction = await context.Database
            .BeginTransactionAsync(cancellationToken);

        try
        {
            foreach (var seeder in seeders.OrderBy(GetOrder))
            {
                await seeder.SeedAsync(cancellationToken);

                await context.SaveChangesAsync(cancellationToken); 

                logger.LogInformation(
                    "Seeder {SeederName} completed.",
                    seeder.GetType().Name);
            }

            await transaction.CommitAsync(cancellationToken);
            logger.LogInformation("All seeders completed.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            logger.LogError(ex, "Seeding failed. Rolled back.");
            throw;
        }
    }
    private static int GetOrder(ISeeder seeder) => seeder switch
    {
        BrandSeeder => 1,
        TypeSeeder => 2,
        ProductSeeder => 3,
        _ => 99
    };
}