namespace Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

public class Resource
{
    public Resource(double cpu, double memory)
    {
        Cpu = cpu;
        Memory = memory;
    }

    /// <summary>
    /// Cpu 
    /// </summary>
    public double Cpu { get; private set; } = default!;
    
    /// <summary>
    /// 内存
    /// </summary>
    public double Memory { get; private set; } = default!;
    
}