using Luck.Framework.Infrastructure;
using Luck.KubeWalnut.Persistence;

namespace Luck.KubeWalnut.Api.AppModules;


[DependsOn(
    typeof(DependencyAppModule),
    typeof(EntityFrameworkCoreModule),
    typeof(MigrationModule)
)]
public class AppWebModule: AppModule
{
    public override void ConfigureServices(ConfigureServicesContext context)
    {
        base.ConfigureServices(context);
            
    }
}