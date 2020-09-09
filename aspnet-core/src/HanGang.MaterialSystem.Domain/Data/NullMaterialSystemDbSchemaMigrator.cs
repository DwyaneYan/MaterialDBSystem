using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HanGang.MaterialSystem.Data
{
    /* This is used if database provider does't define
     * IMaterialSystemDbSchemaMigrator implementation.
     */
    public class NullMaterialSystemDbSchemaMigrator : IMaterialSystemDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}