namespace Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

public class KubernetesNode
{
    public KubernetesNode(string name, string kubernetesVersion, string osImage, string operatingSystem, string containerRuntimeVersion, string ipAddress, Resource capacityResource, Resource allocatableResource, Resource? usageResource)
    {
        KubernetesVersion = kubernetesVersion;
        OSImage = osImage;
        OperatingSystem = operatingSystem;
        ContainerRuntimeVersion = containerRuntimeVersion;
        IpAddress = ipAddress;
        Name = name;
        CapacityResource = capacityResource;
        AllocatableResource = allocatableResource;
        UsageResource = usageResource;
    }

    /// <summary>
    /// 节点名称
    /// </summary>
    public string Name { get; private set; } = default!;
    
    /// <summary>
    /// 版本
    /// </summary>
    public string  KubernetesVersion  { get; private set; } = default!;
    
    /// <summary>
    /// 操作系统
    /// </summary>
    public string  OSImage  { get; private set; } = default!;
    
    /// <summary>
    /// 操作系统类型
    /// </summary>
    public  string OperatingSystem{ get; private set; } = default!;
    
    /// <summary>
    /// Kubernetes Runtime Version
    /// </summary>
    public string ContainerRuntimeVersion{ get; private set; } = default!;
    /// <summary>
    /// IP地址
    /// </summary>
    public string  IpAddress  { get; private set; } = default!;
    
    // /// <summary>
    // /// 版本
    // /// </summary>
    // public string  KubernetesVersion  { get; private set; } = default!;
    
    /// <summary>
    /// 总资源
    /// </summary>
    public Resource CapacityResource { get; private set; } = default!;
    
    /// <summary>
    /// 可分配资源
    /// </summary>
    public Resource AllocatableResource { get; private set; } = default!;
    
    /// <summary>
    /// 已用资源
    /// </summary>
    public Resource? UsageResource { get; private set; }
}