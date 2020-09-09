using System.Threading.Tasks;

namespace HanGang.MaterialSystem.Data
{
    public interface IMaterialSystemDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
