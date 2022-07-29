namespace Luck.KubeWalnut.Dto.Kubernetes;

public class ResourceDto
{
    /// <summary>
    /// Cpu 
    /// </summary>
    public double Cpu { get;  set; }

    /// <summary>
    /// 内存
    /// </summary>
    public double Memory { get;  set; }

    /// <summary>
    /// Pod数量
    /// </summary>
    public int Pod { get;  set; }
}