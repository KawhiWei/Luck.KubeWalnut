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
            double cpu = 0;
            double memory = 0;

            #region 总资源

            if (v1Node.Status.Capacity.TryGetValue(KubernetesConstants.Cpu, out var capacityCpu))
            {
                cpu = Math.Round(capacityCpu.ToDouble() * 100) / 100;
            }

            if (v1Node.Status.Capacity.TryGetValue(KubernetesConstants.Memory, out var capacityMemory))
            {
                memory = Math.Round(capacityMemory.ToDouble() / transferNumber * 100) / 100;
            }

            Resource capacityResource = new Resource(cpu, memory);

            #endregion

            #region 可用资源

            if (v1Node.Status.Allocatable.TryGetValue(KubernetesConstants.Cpu, out var allocatableCpu))
            {
                cpu = Math.Round(allocatableCpu.ToDouble() * 100) / 100;
            }

            if (v1Node.Status.Allocatable.TryGetValue(KubernetesConstants.Memory, out var allocatableMemory))
            {
                memory = Math.Round(allocatableMemory.ToDouble() / transferNumber * 100) / 100;
            }

            Resource allocatableResource = new Resource(cpu, memory);

            #endregion

            #region 已用资源

            Resource? usageResource = null;
            var metric =
                nodeMetricsList.Items.FirstOrDefault(nodeMetrics => nodeMetrics.Metadata.Name == v1Node.Metadata.Name);
            if (metric is not null)
            {
                if (metric.Usage.TryGetValue(KubernetesConstants.Cpu, out var usageCpu))
                {
                    cpu = Math.Round(usageCpu.ToDouble() * 100) / 100;
                }

                if (metric.Usage.TryGetValue(KubernetesConstants.Memory, out var usageMemory))
                {
                    memory = Math.Round(usageMemory.ToDouble() / transferNumber * 100) / 100;
                }

                usageResource = new Resource(cpu, memory);
            }

            #endregion
            List<IpAddress> ipAddresses=  v1Node.Status.Addresses.Select(x=>new IpAddress(x.Type,x.Address)).ToList();
            
            KubernetesNode kubernetesNode = new KubernetesNode(v1Node.Metadata.Name, v1Node.Status.NodeInfo.KubeProxyVersion, v1Node.Status.NodeInfo.OsImage,
                v1Node.Status.NodeInfo.OperatingSystem, v1Node.Status.NodeInfo.ContainerRuntimeVersion, ipAddresses,
                capacityResource, allocatableResource, usageResource);
            return kubernetesNode;
        }));
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