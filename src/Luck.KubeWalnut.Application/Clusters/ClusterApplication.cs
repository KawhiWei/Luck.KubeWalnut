using Luck.Framework.UnitOfWorks;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;
using Luck.KubeWalnut.Domain.Repositories.Clusters;

namespace Luck.KubeWalnut.Application.Clusters;

public class ClusterApplication : IClusterApplication
{
    private readonly IClusterRepository _clusterRepository;

    private readonly IUnitOfWork _unitOfWork;
    public ClusterApplication(IClusterRepository clusterRepository, IUnitOfWork unitOfWork)
    {
        _clusterRepository = clusterRepository;
        _unitOfWork = unitOfWork;
    }

    public Task CreateClusterAsync()
    { 
        _clusterRepository.Add(new Cluster("","","","")
        {
            
        });
        return _unitOfWork.CommitAsync();
    }
}