using System.ComponentModel;

namespace Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

public class Cluster:FullAggregateRoot
{
    /// <summary>
    /// 集群名称
    /// </summary>
    public string Name { get; private set; } = default!;
    
    /// <summary>
    /// 集群昵称
    /// </summary>
    public string NickName { get; private set; } = default!;
    
    /// <summary>
    /// 集群名称
    /// </summary>
    public string Config { get; private set; } = default!;
    
    /// <summary>
    /// 集群版本
    /// </summary>
    public string ClusterVersion { get; private set; } = default!;

}