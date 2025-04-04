using Microsoft.EntityFrameworkCore;

namespace RestService.Infrastructure;

public class RestDbContext : DbContext
{
    public RestDbContext(DbContextOptions<RestDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestDbContext).Assembly);
    }
}