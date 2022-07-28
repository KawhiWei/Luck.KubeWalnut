using k8s;
using Luck.Framework.Infrastructure.DependencyInjectionModule;

namespace Luck.KubeWalnut.Adapter.Factories;

public interface IKubernetesClientFactory:ISingletonDependency
{
    IKubernetes GetKubernetesClient(string configString);
}