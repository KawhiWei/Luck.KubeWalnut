namespace Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;

public class KubernetesStatefulSet:KubernetesResourceBase
{
    public KubernetesStatefulSet(string name) : base(name)
    {
    }
}