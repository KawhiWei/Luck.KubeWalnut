namespace Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;

public class KubernetesCronJob:KubernetesResourceBase
{
    public KubernetesCronJob(string name) : base(name)
    {
    }
}