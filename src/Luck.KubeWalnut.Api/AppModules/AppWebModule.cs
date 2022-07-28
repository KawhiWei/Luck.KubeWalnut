using Luck.Framework.Infrastructure;

namespace Luck.KubeWalnut.Api.AppModules;


[DependsOn(
    typeof(DependencyAppModule)
)]
public class AppWebModule: AppModule
{
    public override void ConfigureServices(ConfigureServicesContext context)
    {
        base.ConfigureServices(context);
            
    }
}