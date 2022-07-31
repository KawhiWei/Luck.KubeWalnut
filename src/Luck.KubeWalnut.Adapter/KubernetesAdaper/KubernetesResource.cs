using k8s;
using k8s.Models;
using Luck.KubeWalnut.Adapter.Constants;
using Luck.KubeWalnut.Adapter.Factories;
using Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;

namespace Luck.KubeWalnut.Adapter.KubernetesAdaper;

public class KubernetesResource : IKubernetesResource
{
    private readonly IKubernetesClientFactory _kubernetesClientFactory;

    private const double TransferNumber = 1_073_741_824;

    public KubernetesResource(IKubernetesClientFactory kubernetesClientFactory)
    {
        _kubernetesClientFactory = kubernetesClientFactory;
    }

    public async Task<KubernetesManager> GetNodeListAsync(string config)
    {
        IKubernetes client = GetClient(config);
        V1NodeList v1NodeList = await client.CoreV1.ListNodeAsync();
        NodeMetricsList nodeMetricsList = await client.GetKubernetesNodesMetricsAsync();
        V1DaemonSetList v1DaemonSetList = await client.AppsV1.ListDaemonSetForAllNamespacesAsync();
        V1PodList v1Pod = await client.CoreV1.ListPodForAllNamespacesAsync();
        var nameSpace = await client.CoreV1.ListNamespaceAsync();

        V1JobList jobs = await client.BatchV1.ListJobForAllNamespacesAsync();
        V1ReplicaSetList replicaSetList = await client.AppsV1.ListReplicaSetForAllNamespacesAsync();

        V1StatefulSetList statefulSetList = await client.AppsV1.ListStatefulSetForAllNamespacesAsync();

        List<KubernetesNode> kubernetesNodes = GetKubernetesNodeList(v1NodeList.Items, nodeMetricsList);
        List<KubernetesDaemonSet> kubernetesNodeDaemonSets = GetkubernetesNodeDaemonSetList(v1DaemonSetList.Items);

        List<KubernetesPod> kubernetesPods = GetKubernetesPodList(v1Pod.Items);


        List<KubernetesJob> kubernetesJobList = jobs.Items.Select(job =>
        {
            KubernetesJob kubernetesJob = new KubernetesJob(job.Metadata.Name);
            return kubernetesJob;
        }).ToList();

        List<KubernetesNamespace> kubernetesNamespaces = nameSpace.Items.Select(nameSpace =>
        {
            KubernetesNamespace kubernetesNamespace = new KubernetesNamespace(nameSpace.Metadata.Name);
            return kubernetesNamespace;
        }).ToList();


        List<KubernetesReplicaSet> kubernetesReplicaSets = replicaSetList.Items.Select(replicaSet =>
        {
            KubernetesReplicaSet kubernetesReplicaSet = new(replicaSet.Metadata.Name);
            return kubernetesReplicaSet;
        }).ToList();


        List<KubernetesStatefulSet> kubernetesStatefulSets = statefulSetList.Items.Select(statefulSet =>
        {
            KubernetesStatefulSet kubernetesStatefulSet = new(statefulSet.Metadata.Name);
            return kubernetesStatefulSet;
        }).ToList();

        KubernetesManager kubernetesManager = new KubernetesManager(kubernetesNodes, kubernetesNodeDaemonSets, kubernetesPods,
            kubernetesJobList, kubernetesNamespaces, kubernetesReplicaSets, kubernetesStatefulSets);

        return kubernetesManager;
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

    public async Task<object> GetPodListAsync(string config)
    {
        IKubernetes client = GetClient(config);


        return "";
    }

    public async Task<object> GetPodListAsync(string config, string nameSpace)
    {
        return "";
    }


    #region 私有方法

    private List<KubernetesPod> GetKubernetesPodList(IList<V1Pod> v1Pods)
    {
        return v1Pods.Select(v1Pod =>
        {
            KubernetesPod kubernetesPod = new KubernetesPod(v1Pod.Metadata.Name, v1Pod.Metadata.NamespaceProperty,
                v1Pod.Metadata.GenerateName, v1Pod.Spec.NodeName, v1Pod.Status.PodIP, v1Pod.Spec.RestartPolicy,
                v1Pod.Status.Phase,
                v1Pod.Spec.SchedulerName, v1Pod.Status.StartTime);
            return kubernetesPod;
        }).ToList();
    }


    private List<KubernetesNode> GetKubernetesNodeList(IList<V1Node> v1Nodes, NodeMetricsList nodeMetricsList)
    {
        return v1Nodes.Select(v1Node =>
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
        }).ToList();
    }

    private List<KubernetesDaemonSet> GetkubernetesNodeDaemonSetList(IList<V1DaemonSet> v1DaemonSets)
    {
        return v1DaemonSets.Select(v1DaemonSet =>
        {
            KubernetesDaemonSet kubernetesDaemonSet =
                new KubernetesDaemonSet(v1DaemonSet.Metadata.Name, v1DaemonSet.Status.CurrentNumberScheduled,
                    v1DaemonSet.Status.DesiredNumberScheduled, v1DaemonSet.Status.NumberAvailable ?? 0,
                    v1DaemonSet.Status.NumberReady);
            return kubernetesDaemonSet;
        }).ToList();
    }

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
            : Math.Round(memoryResourceQuantity.ToDouble() / TransferNumber * 100) / 100;

        int pod = podResourceQuantity?.ToInt32() ?? 0;
        return new Resource(cpu, memory, pod);
    }

    #endregion
}