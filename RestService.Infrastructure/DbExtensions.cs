using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RestService.Infrastructure;

public static class DbExtensions
{
    public static async Task ApplyMigrationsIfNeededAsync<T>(this IHost host, ILogger<T> logger) where T : DbContext
    {
        using var scope = host.Services.CreateScope();
        var factory = scope.ServiceProvider.GetService<IDesignTimeDbContextFactory<T>>();
        await using var db = factory != null ? factory.CreateDbContext([]) : scope.ServiceProvider.GetService<T>();
        
        var pendingMigrations = (await db!.Database.GetPendingMigrationsAsync().ConfigureAwait(false)).ToList();
        logger.LogInformation("{count} pending migrations", pendingMigrations.Count);
        if (pendingMigrations.Count > 0)
        {
            await db.Database.MigrateAsync().ConfigureAwait(false);
            logger.LogInformation("{count} migrations applied", pendingMigrations.Count);
        }
    }
}