using HanGang.MaterialSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HanGang.MaterialSystem.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreMaterialSystemDbSchemaMigrator 
        : IMaterialSystemDbSchemaMigrator, ITransientDependency
    {
        private readonly MaterialSystemMigrationsDbContext _dbContext;

        public EntityFrameworkCoreMaterialSystemDbSchemaMigrator(MaterialSystemMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}