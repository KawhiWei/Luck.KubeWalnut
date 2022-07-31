
using Luck.KubeWalnut.Dto.Clusteries;
using Luck.KubeWalnut.Dto.Kubernetes;

namespace Luck.KubeWalnut.Application.Clusters;

public interface IClusterApplication:IScopedDependency
{
    Task CreateClusterAsync();


    Task<KubernetesClusterMonitoringPanelOutputDto> GetClusterInformationAsync(string id);

    Task<List<ClusterOutputDto>> GetClusterListAsync();
}