using Luck.KubeWalnut.Adapter.Factories;
using k8s;
using k8s.Models;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

namespace Luck.KubeWalnut.Adapter.KubernetesAdaper;

public class KubernetesResource : IKubernetesResource
{
    private readonly IKubernetesClientFactory _kubernetesClientFactory;

    public KubernetesResource(IKubernetesClientFactory kubernetesClientFactory)
    {
        _kubernetesClientFactory = kubernetesClientFactory;
    }

    public async Task<List<KubernetesNode>> GetNodeListAsync()
    {

        IKubernetes client = GetClient("");
        V1NodeList v1NodeList = await client.CoreV1.ListNodeAsync();
        NodeMetricsList nodeMetricsList=   await client.GetKubernetesNodesMetricsAsync();
        List<KubernetesNode> kubernetesNodes = new List<KubernetesNode>(v1NodeList.Items.Count);


        v1NodeList.Items.Select(x =>
        {
            
            Resource capacityResource=new Resource()
            {
                
            }
            KubernetesNode node = new KubernetesNode(x.Metadata.Name);


            return node;


        });
        
        
        return kubernetesNodes;
    }

    public void GetNameSpaceListAsync()
    {
        throw new NotImplementedException();
    }

    public void GetPodListAsync()
    {
        throw new NotImplementedException();
    }

    public void GetPodListAsync(string nameSpace)
    {
        throw new NotImplementedException();
    }

    private async Task<NodeMetricsList> GetKubernetesNodesMetricsAsync(IKubernetes client)
    {
        return await client.GetKubernetesNodesMetricsAsync();
    }


    private IKubernetes GetClient(string config)
    {
        return _kubernetesClientFactory.GetKubernetesClient(config);
    }
}