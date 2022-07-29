namespace Luck.KubeWalnut.Dto.Kubernetes;

public class KubernetesNodeOutputDto
{
    /// <summary>
    /// 节点名称
    /// </summary>
    public string Name { get;  set; }= default!;

    /// <summary>
    /// 版本
    /// </summary>
    public string KubernetesVersion { get;  set; }= default!;

    /// <summary>
    /// 操作系统
    /// </summary>
    public string OsImage { get;  set; }= default!;

    /// <summary>
    /// 操作系统类型
    /// </summary>
    public string OperatingSystem { get;  set; }= default!;

    /// <summary>
    /// Kubernetes Runtime Version
    /// </summary>
    public string ContainerRuntimeVersion { get;  set; }= default!;
    
    /// <summary>
    /// 总资源
    /// </summary>
    public ResourceDto CapacityResource { get; set; } = new ResourceDto();

    /// <summary>
    /// 可分配资源
    /// </summary>
    public ResourceDto AllocatableResource { get;  set; } = new ResourceDto();

    /// <summary>
    /// 已用资源
    /// </summary>
    public ResourceDto UsageResource { get;  set; } = new ResourceDto();

    /// <summary>
    /// Ip地址列表
    /// </summary>
    public List<IpAddressesOutputDto> IpAddresses { get; set; } = new List<IpAddressesOutputDto>();
}