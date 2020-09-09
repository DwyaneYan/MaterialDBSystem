using HanGang.MaterialSystem.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HanGang.MaterialSystem
{
    [DependsOn(
        typeof(MaterialSystemEntityFrameworkCoreTestModule)
        )]
    public class MaterialSystemDomainTestModule : AbpModule
    {
    }
}