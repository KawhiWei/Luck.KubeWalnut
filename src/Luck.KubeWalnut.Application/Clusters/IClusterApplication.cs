
namespace Luck.KubeWalnut.Application.Clusters;

public interface IClusterApplication:IScopedDependency
{
    Task CreateClusterAsync();
}