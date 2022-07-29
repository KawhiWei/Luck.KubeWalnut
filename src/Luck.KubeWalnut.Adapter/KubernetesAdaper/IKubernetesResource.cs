using Luck.Framework.Infrastructure.DependencyInjectionModule;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

namespace Luck.KubeWalnut.Adapter.KubernetesAdaper;

public interface IKubernetesResource:IScopedDependency
{
     /// <summary>
     /// 获取K8s节点信息
     /// </summary>
     /// <returns></returns>
     Task<List<KubernetesNode>> GetNodeListAsync(string config);


     Task GetNameSpaceListAsync(string config);


     void GetPodListAsync();
     
     void GetPodListAsync(string nameSpace);

}