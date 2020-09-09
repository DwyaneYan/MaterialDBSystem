using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace HanGang.MaterialSystem.EntityFrameworkCore
{
    [DependsOn(
        typeof(MaterialSystemEntityFrameworkCoreModule)
        )]
    public class MaterialSystemEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MaterialSystemMigrationsDbContext>();
        }
    }
}
