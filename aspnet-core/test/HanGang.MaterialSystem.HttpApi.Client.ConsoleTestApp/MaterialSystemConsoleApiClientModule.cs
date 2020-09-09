using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace HanGang.MaterialSystem.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(MaterialSystemHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
    )]
    public class MaterialSystemConsoleApiClientModule : AbpModule
    {
    }
}
