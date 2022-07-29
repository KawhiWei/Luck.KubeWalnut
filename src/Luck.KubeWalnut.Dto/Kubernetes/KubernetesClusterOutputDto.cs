namespace Luck.KubeWalnut.Dto.Kubernetes;

public class KubernetesClusterOutputDto
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
    /// 节点列表
    /// </summary>
    public List<KubernetesNodeOutputDto> Nodes { get; set; } = new List<KubernetesNodeOutputDto>();
}