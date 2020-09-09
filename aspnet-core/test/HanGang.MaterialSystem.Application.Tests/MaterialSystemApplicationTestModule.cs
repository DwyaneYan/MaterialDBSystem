using Volo.Abp.Modularity;

namespace HanGang.MaterialSystem
{
    [DependsOn(
        typeof(MaterialSystemApplicationModule),
        typeof(MaterialSystemDomainTestModule)
        )]
    public class MaterialSystemApplicationTestModule : AbpModule
    {
    }
}