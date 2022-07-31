namespace Luck.KubeWalnut.Domain.AggregateRoots.Kubernetes;

public class Resource
{
    public Resource(double cpu, double memory, int pod)
    {
        Cpu = cpu;
        Memory = memory;
        Pod = pod;
    }

    /// <summary>
    /// Cpu 
    /// </summary>
    public double Cpu { get; private set; }

    /// <summary>
    /// 内存
    /// </summary>
    public double Memory { get; private set; }

    /// <summary>
    /// Pod数量
    /// </summary>
    public int Pod { get; private set; }
}