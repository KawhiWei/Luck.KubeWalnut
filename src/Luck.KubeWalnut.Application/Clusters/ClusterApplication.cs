using Luck.Framework.UnitOfWorks;
using Luck.KubeWalnut.Adapter.KubernetesAdaper;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;
using Luck.KubeWalnut.Domain.Repositories.Clusters;
using Luck.KubeWalnut.Dto.Kubernetes;

namespace Luck.KubeWalnut.Application.Clusters;

public class ClusterApplication : IClusterApplication
{

    private readonly IKubernetesResource _kubernetesResource; 
    public ClusterApplication(IKubernetesResource kubernetesResource)
    {
        _kubernetesResource = kubernetesResource;
    }

    public Task CreateClusterAsync()
    { 
       return  Task.CompletedTask;
    }


    public async Task<KubernetesClusterOutputDto> GetClusterInformationAsync(string config)
    {
       var nodes= await _kubernetesResource.GetNodeListAsync(config);
       return  GetKubernetesClusterOutputDto(nodes);
    }


    private KubernetesClusterOutputDto GetKubernetesClusterOutputDto(List<KubernetesNode>  kubernetesNodes)
    {
        var kubernetesClusterOutputDto = new KubernetesClusterOutputDto()
        {
            ClusterTotalCpuCapacity = kubernetesNodes.Sum(node => node.CapacityResource.Cpu),
            ClusterTotalCpuUsage = kubernetesNodes.Sum(node => node.UsageResource.Cpu),

            ClusterTotalMemoryCapacity = kubernetesNodes.Sum(node => node.CapacityResource.Memory),
            ClusterTotalMemoryUsage = kubernetesNodes.Sum(node => node.UsageResource.Memory),
            Nodes = GetKubernetesNodeOutputDtos(kubernetesNodes),
        };

        return kubernetesClusterOutputDto;
    }

    private List<KubernetesNodeOutputDto> GetKubernetesNodeOutputDtos (List<KubernetesNode>  kubernetesNodes)
    {
        return  kubernetesNodes.Select(x => new KubernetesNodeOutputDto()
        {
            Name = x.Name,
            KubernetesVersion = x.KubernetesVersion,
            OsImage = x.OsImage,
            OperatingSystem = x.OperatingSystem,
            ContainerRuntimeVersion = x.ContainerRuntimeVersion,
            CapacityResource = new ResourceDto()
            {
                Cpu = x.CapacityResource.Cpu,
                Memory = x.CapacityResource.Memory,
                Pod = x.CapacityResource.Pod,
            },
            AllocatableResource = new ResourceDto() {
                Cpu = x.AllocatableResource.Cpu,
                Memory = x.AllocatableResource.Memory,
                Pod = x.AllocatableResource.Pod,
            },
            UsageResource = new ResourceDto()
            {
                Cpu = x.UsageResource.Cpu,
                Memory = x.UsageResource.Memory,
                Pod = x.UsageResource.Pod,
            },
        }).ToList();
    }
}