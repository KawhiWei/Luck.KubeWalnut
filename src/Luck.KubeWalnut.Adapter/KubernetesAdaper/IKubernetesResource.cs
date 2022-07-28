using Luck.Framework.Infrastructure.DependencyInjectionModule;

namespace Luck.KubeWalnut.Adapter.KubernetesAdaper;

public interface IKubernetesResource:IScopedDependency
{


     void GetNodeListAsync();


     void GetNameSpaceListAsync();


     void GetPodListAsync();
     
     void GetPodListAsync(string nameSpace);

}