namespace Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

public class IpAddress
{
    public IpAddress(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public string Name { get; set; }

    public string Address { get; set; }
}