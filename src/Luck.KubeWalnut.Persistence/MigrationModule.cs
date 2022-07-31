using Luck.Framework.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Luck.KubeWalnut.Persistence;

public class MigrationModule: AppModule
{

    public override void ApplicationInitialization(ApplicationContext context)
    {

        var moduleDbContext = context.ServiceProvider.GetService<KubeWalnutDbContext>();
        moduleDbContext?.Database.EnsureCreated();
    }

}