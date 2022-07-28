namespace Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

public class KubernetesNode
{
    public KubernetesNode(string name, Resource capacityResource, Resource allocatableResource, Resource usageResource)
    {
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
    public Resource UsageResource { get; private set; } = default!;
}


public class Resource
{
    /// <summary>
    /// Cpu 
    /// </summary>
    public int Cpu { get; private set; } = default!;
    
    /// <summary>
    /// 内存
    /// </summary>
    public int Memory { get; private set; } = default!;
    
}