using System.Reflection;
using Luck.EntityFrameworkCore.DbContexts;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

namespace Luck.KubeWalnut.Persistence;

public class KubeWalnutDbContext: LuckDbContextBase
{
    public KubeWalnutDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
    {
    }
    
    public DbSet<Cluster> AppConfigurations => Set<Cluster>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("luck.walnut");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}