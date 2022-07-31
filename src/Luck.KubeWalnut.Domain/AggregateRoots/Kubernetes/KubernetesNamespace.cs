namespace Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;

public class KubernetesNamespace:KubernetesResourceBase
{
    public KubernetesNamespace(string name) : base(name)
    {
    }
}