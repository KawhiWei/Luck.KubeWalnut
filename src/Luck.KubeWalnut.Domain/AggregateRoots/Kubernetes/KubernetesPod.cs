namespace Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;

public class KubernetesPod:KubernetesResourceBase
{
    public KubernetesPod(string name, string namespaceProperty, string generateName, string nodeName, string podIp, string restartPolicy, string phase, string schedulerName, DateTime? startTime):base(name)
    {
        NamespaceProperty = namespaceProperty;
        GenerateName = generateName;
        NodeName = nodeName;
        PodIp = podIp;
        RestartPolicy = restartPolicy;
        Phase = phase;
        SchedulerName = schedulerName;
        StartTime = startTime;
    }
    /// <summary>
    /// 镜像
    /// </summary>
    public string NamespaceProperty { get; private set; }
  

    
    public string GenerateName { get; private set; }
    
    
    public string NodeName { get; private set; }
    
    public string PodIp { get; private set; }
    
    
    public string RestartPolicy { get; private set; }
    
    public string Phase { get; private set; }
    
    public string SchedulerName { get; private set; }
    public DateTime? StartTime { get; private set; }

        
        
    
    
    
    
    
        
    
        
}