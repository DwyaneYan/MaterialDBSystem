using HanGang.MaterialSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace HanGang.MaterialSystem.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(MaterialSystemEntityFrameworkCoreDbMigrationsModule),
        typeof(MaterialSystemApplicationContractsModule)
        )]
    public class MaterialSystemDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
