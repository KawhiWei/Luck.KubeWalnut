using Luck.KubeWalnut.Adapter.Factories;
using k8s;
using k8s.Models;
using Luck.KubeWalnut.Adapter.Constants;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

namespace Luck.KubeWalnut.Adapter.KubernetesAdaper;

public class KubernetesResource : IKubernetesResource
{
    private readonly IKubernetesClientFactory _kubernetesClientFactory;

    private const double transferNumber = 1_073_741_824;

    public KubernetesResource(IKubernetesClientFactory kubernetesClientFactory)
    {
        _kubernetesClientFactory = kubernetesClientFactory;
    }

    public async Task<List<KubernetesNode>> GetNodeListAsync(string config)
    {
        IKubernetes client = GetClient(config);
        V1NodeList v1NodeList = await client.CoreV1.ListNodeAsync();
        NodeMetricsList nodeMetricsList = await client.GetKubernetesNodesMetricsAsync();
        List<KubernetesNode> kubernetesNodes = new List<KubernetesNode>(v1NodeList.Items.Count);
        kubernetesNodes.AddRange(v1NodeList.Items.Select(v1Node =>
        {
            Resource capacityResource = CreateResource(v1Node.Status.Capacity) ??
                                        new Resource(0, 0, 0);

            Resource allocatableResource = CreateResource(v1Node.Status.Allocatable) ??
                                           new Resource(0, 0, 0);

            Resource? usageResource = new Resource(0, 0, 0);
            var metric =
                nodeMetricsList.Items.FirstOrDefault(nodeMetrics => nodeMetrics.Metadata.Name == v1Node.Metadata.Name);
            if (metric is not null)
            {
                usageResource = CreateResource(metric.Usage) ??
                                new Resource(0, 0, 0);
            }
            List<IpAddress> ipAddresses =
                v1Node.Status.Addresses.Select(x => new IpAddress(x.Type, x.Address)).ToList();

            KubernetesNode kubernetesNode = new KubernetesNode(v1Node.Metadata.Name,
                v1Node.Status.NodeInfo.KubeProxyVersion, v1Node.Status.NodeInfo.OsImage,
                v1Node.Status.NodeInfo.OperatingSystem, v1Node.Status.NodeInfo.ContainerRuntimeVersion, ipAddresses,
                capacityResource, allocatableResource, usageResource);

            
            return kubernetesNode;
        }));
        return kubernetesNodes;
    }

    public async Task GetNameSpaceListAsync(string config)
    {
        IKubernetes client = GetClient(config);
        var nameSpace = await client.CoreV1.ListNamespaceAsync();
        foreach (var item in nameSpace.Items)
        {
            Console.WriteLine(item.Metadata.Name);
        }
    }

    public void GetPodListAsync()
    {
        throw new NotImplementedException();
    }

    public void GetPodListAsync(string nameSpace)
    {
        throw new NotImplementedException();
    }



    #region 私有方法

    private IKubernetes GetClient(string config)
    {
        return _kubernetesClientFactory.GetKubernetesClient(config);
    }

    private ResourceQuantity? GetResourceQuantity(string key, IDictionary<string, ResourceQuantity> allocatable)
    {
        if (allocatable.TryGetValue(key, out var resourceQuantity))
        {
            return resourceQuantity;
        }

        return null;
    }


    private Resource? CreateResource(
        IDictionary<string, ResourceQuantity> resourceQuantities)
    {
        ResourceQuantity? cpuResourceQuantity = null;
        ResourceQuantity? memoryResourceQuantity = null;
        ResourceQuantity? podResourceQuantity = null;

        cpuResourceQuantity = GetResourceQuantity(KubernetesConstants.Cpu, resourceQuantities);
        memoryResourceQuantity = GetResourceQuantity(KubernetesConstants.Memory, resourceQuantities);
        podResourceQuantity = GetResourceQuantity(KubernetesConstants.Pod, resourceQuantities);
        
        double cpu = cpuResourceQuantity == null ? 0 : Math.Round(cpuResourceQuantity.ToDouble() * 100) / 100;
        double memory = memoryResourceQuantity == null
            ? 0
            : Math.Round(memoryResourceQuantity.ToDouble() / transferNumber * 100) / 100;

        int pod = podResourceQuantity?.ToInt32() ?? 0;
        return new Resource(cpu, memory, pod);
    }

    #endregion
    
}