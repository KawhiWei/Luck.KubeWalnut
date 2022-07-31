namespace Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;

public class KubernetesDaemonSet:KubernetesResourceBase
{
    public KubernetesDaemonSet(string name, int currentNumberScheduled, int desiredNumberScheduled, int numberAvailable, int numberReady):base(name)
    {
        CurrentNumberScheduled = currentNumberScheduled;
        DesiredNumberScheduled = desiredNumberScheduled;
        NumberAvailable = numberAvailable;
        NumberReady = numberReady;
    }

    /// <summary>
    /// 
    /// </summary>
    public int CurrentNumberScheduled { get; private set; } = default!;
    
    /// <summary>
    /// 
    /// </summary>
    public int DesiredNumberScheduled { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public int NumberAvailable { get; private set; } = default!;
    
    /// <summary>
    /// 
    /// </summary>
    public int NumberReady { get; private set; } = default!;
}