using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;

namespace Luck.KubeWalnut.Persistence.Configurations;

public class ClusterMapConfiguration: IEntityTypeConfiguration<Cluster>
{
    public void Configure(EntityTypeBuilder<Cluster> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("kubewalnut_clusters");
    }
}