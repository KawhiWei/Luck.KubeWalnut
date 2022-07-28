using Luck.Framework.Infrastructure.DependencyInjectionModule;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

namespace Luck.KubeWalnut.Adapter.KubernetesAdaper;

public interface IKubernetesResource:IScopedDependency
{
     Task<List<KubernetesNode>> GetNodeListAsync();


     void GetNameSpaceListAsync();


     void GetPodListAsync();
     
     void GetPodListAsync(string nameSpace);

}