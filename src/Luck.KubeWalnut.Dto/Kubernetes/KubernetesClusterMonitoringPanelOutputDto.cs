namespace Luck.KubeWalnut.Dto.Kubernetes;

public class KubernetesClusterMonitoringPanelOutputDto
{
    
    /// <summary>
    /// 集群总CPU核心数
    /// </summary>
    public double ClusterTotalCpuCapacity { get; set; }= default!;
    
    /// <summary>
    /// 集群Cpu总使用量
    /// </summary>
    public  double ClusterTotalCpuUsage { get; set; }= default!;
    
    /// <summary>
    /// 集群总内存
    /// </summary>
    public  double ClusterTotalMemoryCapacity { get; set; }= default!;
    
    /// <summary>
    /// 集群内存总使用量
    /// </summary>
    public  double ClusterTotalMemoryUsage { get; set; }= default!;

    /// <summary>
    /// 集群可部署pod数量
    /// </summary>
    public  int ClusterTotalPodCapacity { get; set; }= default!;

    /// <summary>
    /// 集群已部署pod数量 
    /// </summary>
    public int ClusterTotalPodUsage { get; set; }
    
    public int DaemonSetTotal { get; set; } = default!;
    
    public int JobTotal { get; set; } = default!;
    
    public int NamespaceTotal { get; set; } = default!;
    
    public int ReplicaSetTotal { get; set; } = default!;
    
    public int StatefulSetTotal { get; set; } = default!;
    
    /// <summary>
    /// 节点列表
    /// </summary>
    public List<KubernetesNodeOutputDto> Nodes { get; set; } = new List<KubernetesNodeOutputDto>();
}