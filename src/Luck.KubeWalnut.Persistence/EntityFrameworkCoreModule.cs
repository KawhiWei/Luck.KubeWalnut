using Luck.EntityFrameworkCore;
using Luck.EntityFrameworkCore.DbContextDrivenProvides;
using Microsoft.Extensions.DependencyInjection;

namespace Luck.KubeWalnut.Persistence;

public class EntityFrameworkCoreModule: EntityFrameworkCoreBaseModule
{
    public override void AddDbContextWithUnitOfWork(IServiceCollection services)
    {
        services.AddLuckDbContext<KubeWalnutDbContext>(x =>
        {
            x.ConnnectionString = "User ID=postgres;Password=wzw0126..;Host=192.168.31.30;Port=5432;Database=luck.kubewalnut";
            x.Type = DataBaseType.PostgreSQL;
        });
    }

    public override void AddDbDriven(IServiceCollection service)
    {
        service.AddPostgreSQLDriven();
    }
}
