using Luck.KubeWalnut.Application.Clusters;
using Luck.KubeWalnut.Dto.Clusteries;
using Luck.KubeWalnut.Dto.Kubernetes;
using Microsoft.AspNetCore.Mvc;

namespace Luck.KubeWalnut.Api.Controllers;

/// <summary>
/// 集群管理
/// </summary>
[Route("api/clusters")]
public class ClusterController : BaseController
{
    private readonly IClusterApplication _clusterApplication;
    public ClusterController(IClusterApplication clusterApplication)
    {
        _clusterApplication = clusterApplication;
    }

    [HttpPost]
    public async Task CreateCluster()
    {
        await _clusterApplication.CreateClusterAsync();
    }

    [HttpGet("{id}")]
    public async Task<KubernetesClusterMonitoringPanelOutputDto> GetClusterInformationAsync(string id)
    {
        return await _clusterApplication.GetClusterInformationAsync(id);
    }

    [HttpGet("clusterlist")]
    public Task<List<ClusterOutputDto>> GetClusterList()
    {
        return _clusterApplication.GetClusterListAsync();
    }
    
}