namespace Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;

public class KubernetesManager
{
    public KubernetesManager(List<KubernetesNode> kubernetesNodes, List<KubernetesDaemonSet> kubernetesNodeDaemonSets,
        List<KubernetesPod> kubernetesPods, List<KubernetesJob> kubernetesJobs,
        List<KubernetesNamespace> kubernetesNamespaces, List<KubernetesReplicaSet> kubernetesReplicaSets,
        List<KubernetesStatefulSet> kubernetesStatefulSets)
    {
        KubernetesNodes = kubernetesNodes;
        KubernetesNodeDaemonSets = kubernetesNodeDaemonSets;
        KubernetesPods = kubernetesPods;
        KubernetesJobs = kubernetesJobs;
        KubernetesNamespaces = kubernetesNamespaces;
        KubernetesReplicaSets = kubernetesReplicaSets;
        KubernetesStatefulSets = kubernetesStatefulSets;
    }

    /// <summary>
    /// 集群节点列表
    /// </summary>
    public List<KubernetesNode> KubernetesNodes { get; private set; }

    /// <summary>
    /// DaemonSet列表
    /// </summary>
    public List<KubernetesDaemonSet> KubernetesNodeDaemonSets { get; private set; }

    /// <summary>
    /// Pod列表
    /// </summary>
    public List<KubernetesPod> KubernetesPods { get; private set; }

    public List<KubernetesJob> KubernetesJobs { get; private set; }


    public List<KubernetesNamespace> KubernetesNamespaces { get; private set; }


    public List<KubernetesReplicaSet> KubernetesReplicaSets { get; private set; }


    public List<KubernetesStatefulSet> KubernetesStatefulSets { get; private set; }

    public double GetClusterTotalCpuCapacity()
    {
        return KubernetesNodes.Sum(node => node.CapacityResource.Cpu);
    }

    public double GetClusterTotalCpuUsage()
    {
        return KubernetesNodes.Sum(node => node.UsageResource.Cpu);
    }

    public double GetClusterTotalMemoryCapacity()
    {
        return KubernetesNodes.Sum(node => node.CapacityResource.Memory);
    }

    public double GetClusterTotalMemoryUsage()
    {
        return KubernetesNodes.Sum(node => node.UsageResource.Memory);
    }

    public int GetClusterTotalPodCapacity()
    {
        return KubernetesNodes.Sum(node => node.CapacityResource.Pod);
    }
}