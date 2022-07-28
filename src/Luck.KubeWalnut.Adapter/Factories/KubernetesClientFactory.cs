using System.Text;
using k8s;

namespace Luck.KubeWalnut.Adapter.Factories;

public class KubernetesClientFactory:IKubernetesClientFactory
{
    public IKubernetes GetKubernetesClient(string configString)
    {
        byte[] array = Encoding.ASCII.GetBytes(configString);
        MemoryStream stream = new MemoryStream(array);
        var config=KubernetesClientConfiguration.BuildConfigFromConfigFile(stream);
        return new Kubernetes(config);
    }
}