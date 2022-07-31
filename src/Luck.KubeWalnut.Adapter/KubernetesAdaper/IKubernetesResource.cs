using Luck.Framework.Infrastructure.DependencyInjectionModule;
using Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;

namespace Luck.KubeWalnut.Adapter.KubernetesAdaper;

public interface IKubernetesResource:IScopedDependency
{
     /// <summary>
     /// 获取K8s节点信息
     /// </summary>
     /// <returns></returns>
     Task<KubernetesManager> GetNodeListAsync(string config);


     Task GetNameSpaceListAsync(string config);


     Task<object> GetPodListAsync(string config);
     
     Task<object> GetPodListAsync(string config,string nameSpace);

}