namespace Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;

public class KubernetesNode:KubernetesResourceBase
{
    public KubernetesNode(string name, string kubernetesVersion, string osImage, string operatingSystem,
        string containerRuntimeVersion, List<IpAddress> ipAddresses, Resource capacityResource, Resource allocatableResource,
        Resource usageResource):base(name)
    {
        KubernetesVersion = kubernetesVersion;
        OsImage = osImage;
        OperatingSystem = operatingSystem;
        ContainerRuntimeVersion = containerRuntimeVersion;
        IpAddresses = new List<IpAddress>(ipAddresses);
        CapacityResource = capacityResource;
        AllocatableResource = allocatableResource;
        UsageResource = usageResource;
        
        
    }

    /// <summary>
    /// 版本
    /// </summary>
    public string KubernetesVersion { get; private set; }

    /// <summary>
    /// 操作系统
    /// </summary>
    public string OsImage { get; private set; }

    /// <summary>
    /// 操作系统类型
    /// </summary>
    public string OperatingSystem { get; private set; }

    /// <summary>
    /// KubernetesManager Runtime Version
    /// </summary>
    public string ContainerRuntimeVersion { get; private set; }

    /// <summary>
    /// 总资源
    /// </summary>
    public Resource CapacityResource { get; private set; }

    /// <summary>
    /// 可分配资源
    /// </summary>
    public Resource AllocatableResource { get; private set; }

    /// <summary>
    /// 已用资源
    /// </summary>
    public Resource UsageResource { get; private set; }

    /// <summary>
    /// Ip地址列表
    /// </summary>
    public List<IpAddress> IpAddresses { get; private set; }




    #region Method

    #endregion

}