using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Luck.KubeWalnut.Adapter.KubernetesAdaper;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;
using Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;
using Luck.KubeWalnut.Domain.Repositories.Clusters;
using Luck.KubeWalnut.Dto.Clusteries;
using Luck.KubeWalnut.Dto.Kubernetes;


namespace Luck.KubeWalnut.Application.Clusters;

public class ClusterApplication : IClusterApplication
{
    private readonly IKubernetesResource _kubernetesResource;
    private readonly IClusterRepository _clusterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ClusterApplication(IKubernetesResource kubernetesResource, IClusterRepository clusterRepository,
        IUnitOfWork unitOfWork)
    {
        _kubernetesResource = kubernetesResource;
        _clusterRepository = clusterRepository;
        _unitOfWork = unitOfWork;
    }

    public Task CreateClusterAsync()
    {
        _clusterRepository.Add(new Cluster("Luck生产集群", "esxik8s集群", @"", "v1.22.12-3+dba78d63ae38c7"));
        return _unitOfWork.CommitAsync();
    }


    public async Task<KubernetesClusterMonitoringPanelOutputDto> GetClusterInformationAsync(string id)
    {
        var cluster = await _clusterRepository.FindAll().FirstOrDefaultAsync(x => x.Id ==id);
        if (cluster is null)
            throw new BusinessException("集群不存在");
        var kubernetes = await _kubernetesResource.GetNodeListAsync(cluster.Config);
        return GetKubernetesClusterOutputDto(kubernetes);
    }


    public Task<List<ClusterOutputDto>> GetClusterListAsync()
    {
        return _clusterRepository.FindAll().Select(x => new ClusterOutputDto()
        {
            Id = x.Id,
            Name = x.Name,
            NickName = x.NickName
        }).ToListAsync();
    }


    private KubernetesClusterMonitoringPanelOutputDto GetKubernetesClusterOutputDto(KubernetesManager kubernetesManager)
    {
        var kubernetesClusterOutputDto = new KubernetesClusterMonitoringPanelOutputDto()
        {
            ClusterTotalCpuCapacity = kubernetesManager.GetClusterTotalCpuCapacity(),
            ClusterTotalCpuUsage = kubernetesManager.GetClusterTotalCpuUsage(),

            ClusterTotalMemoryCapacity = kubernetesManager.GetClusterTotalMemoryCapacity(),
            ClusterTotalMemoryUsage = kubernetesManager.GetClusterTotalMemoryUsage(),
            Nodes = GetKubernetesNodeOutputDtos(kubernetesManager.KubernetesNodes),
            ClusterTotalPodCapacity = kubernetesManager.GetClusterTotalPodCapacity(),
            DaemonSetTotal = kubernetesManager.KubernetesNodeDaemonSets.Count,
            ClusterTotalPodUsage = kubernetesManager.KubernetesPods.Count,
            JobTotal = kubernetesManager.KubernetesJobs.Count,
            StatefulSetTotal = kubernetesManager.KubernetesStatefulSets.Count,
            NamespaceTotal = kubernetesManager.KubernetesNamespaces.Count,
            ReplicaSetTotal = kubernetesManager.KubernetesReplicaSets.Count,
        };
        return kubernetesClusterOutputDto;
    }

    private List<KubernetesNodeOutputDto> GetKubernetesNodeOutputDtos(List<KubernetesNode> kubernetesNodes)
    {
        return kubernetesNodes.Select(x => new KubernetesNodeOutputDto()
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
            AllocatableResource = new ResourceDto()
            {
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
            IpAddresses = x.IpAddresses.Select(a => new IpAddressesOutputDto() { Address = a.Address, Name = a.Name })
                .ToList(),
        }).ToList();
    }
}