using Luck.DDD.Domain.Repositories;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

namespace Luck.KubeWalnut.Domain.Repositories.Clusters;

public interface IClusterRepository: IAggregateRootRepository<Cluster,string>,IScopedDependency
{
    
}