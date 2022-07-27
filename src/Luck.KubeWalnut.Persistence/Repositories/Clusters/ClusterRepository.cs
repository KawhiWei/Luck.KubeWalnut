using Luck.EntityFrameworkCore.DbContexts;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;
using Luck.KubeWalnut.Domain.Repositories.Clusters;

namespace Luck.KubeWalnut.Persistence.Repositories.Clusters;


public class ClusterRepository: EFCoreAggregateRootRepository<Cluster, string>,IClusterRepository
{
    public ClusterRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }


    public async Task<object> GetAllClusterListAsync()
    {
       return  await this.FindAll().ToListAsync();
    }
    
}