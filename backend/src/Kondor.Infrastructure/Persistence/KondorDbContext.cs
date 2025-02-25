using Microsoft.EntityFrameworkCore;
using Kondor.Domain.Entities;

namespace Kondor.Infrastructure.Persistence;

public class KondorDbContext : DbContext
{
    public KondorDbContext(DbContextOptions<KondorDbContext> options)
        : base(options)
    {
    }

    public DbSet<DatabaseConnection> Connections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KondorDbContext).Assembly);
    }
}