using HanGang.MaterialSystem.DemoManagement;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.Rbac;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using HanGang.MaterialSystem.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;

namespace HanGang.MaterialSystem.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See MaterialSystemMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class MaterialSystemDbContext : AbpDbContext<MaterialSystemDbContext>
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleResource> RoleResources { get; set; }
        public DbSet<TrialCategory> TrialCategorys { get; set; }
        public DbSet<TrialDetailGroup> TrialDetailGroups { get; set; }

        public DbSet<TrialDetailShowType> TrialDetailShowTypes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> NBUsers { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<DemoProject> DemoProjects { get; set; }
        public DbSet<DemoUnitProject> DemoUnitProjects { get; set; }
        public DbSet<TypicalPart> TypicalParts { get; set; }
        public DbSet<Manufactory> Manufactorys { get; set; }
        public DbSet<Trial> Trials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ApplicationCase> ApplicationCases { get; set; }
        public DbSet<MaterialRecommendation> MaterialRecommendations { get; set; }
        public DbSet<MaterialTrial> MaterialTrials { get; set; }
        public DbSet<MaterialTrialData> MaterialTrialDatas { get; set; }
        public DbSet<StaticTensionDataDetail> StaticTensionDataDetails { get; set; }
        public DbSet<StaticTensionDataDetailRequirement> StaticTensionDataDetailRequirements { get; set; }
        public DbSet<StaticTensionDataDetailStressStrain> StaticTensionDataDetailStressStrains { get; set; }
        public DbSet<BendingDataDetail> BendingDataDetails { get; set; }
        public DbSet<CompressDataDetail> CompressDataDetails { get; set; }
        public DbSet<HighSpeedStrechDataDetail> HighSpeedStrechDataDetails { get; set; }
        public DbSet<HighSpeedStrechDataDetailStressStrain> HighSpeedStrechDataDetailStressStrains { get; set; }
        public DbSet<HighSpeedStrechDataDetailStressStrainExtend> HighSpeedStrechDataDetailStressStrainExtends { get; set; }
        public DbSet<LowCycleFatigueDataDetail> LowCycleFatigueDataDetails { get; set; }
        public DbSet<LowCycleFatigueDataDetailItem> LowCycleFatigueDataDetailItems { get; set; }
        public DbSet<HighCycleFatigueDataDetail> HighCycleFatigueDataDetails { get; set; }
        public DbSet<HighCycleFatigueDataDetailItem> HighCycleFatigueDataDetailItems { get; set; }
        public DbSet<MetallographicDataDetail> MetallographicDataDetails { get; set; }
        public DbSet<PhysicalPerformanceDataDetail> PhysicalPerformanceDataDetails { get; set; }
        public DbSet<PhysicalPerformanceDataDetailThermalExpansion> PhysicalPerformanceDataDetailThermalExpansions { get; set; }
        public DbSet<PhysicalPerformanceDataDetailThermalConductivity> PhysicalPerformanceDataDetailThermalConductivities { get; set; }
        public DbSet<ChemicalElementDataDetail> ChemicalElementDataDetails { get; set; }
        public DbSet<ProhibitedSubstanceDataDetail> ProhibitedSubstanceDataDetails { get; set; }
        public DbSet<SurfacePropertyDataDetail> SurfacePropertyDataDetails { get; set; }
        public DbSet<SurfacePropertyCoatingWeight> SurfacePropertyCoatingWeights { get; set; }
        public DbSet<SurfacePropertyRoughness> SurfacePropertyRoughnesses { get; set; }
        public DbSet<SurfacePropertyRoughnessAndPeakDensity> SurfacePropertyRoughnessAndPeakDensitys { get; set; }
        public DbSet<SurfacePropertySizeTolerance> SurfacePropertySizeTolerances { get; set; }
        public DbSet<DentResistanceDataDetail> DentResistanceDataDetails { get; set; }
        public DbSet<SecondaryWorkingEmbrittlementDataDetail> SecondaryWorkingEmbrittlementDataDetails { get; set; }
        public DbSet<SecondaryWorkingEmbrittlementDataDetailItem> SecondaryWorkingEmbrittlementDataDetailItems { get; set; }
        public DbSet<FlangingClaspDataDetail> FlangingClaspDataDetails { get; set; }
        public DbSet<HydrogenInducedDelayedFractureDataDetail> HydrogenInducedDelayedFractureDataDetails { get; set; }
        public DbSet<HydrogenInducedDelayedFractureDataDetailItem> HydrogenInducedDelayedFractureDataDetailItems { get; set; }
        public DbSet<WeldingDataDetail> WeldingDataDetails { get; set; }
        public DbSet<WeldingDataDetailItem> WeldingDataDetailItems { get; set; }
        public DbSet<CementingDataDetail> CementingDataDetails { get; set; }
        public DbSet<PaintingDataDetail> PaintingDataDetail { get; set; }
        public DbSet<PaintingDataDetailPhosphatingItem> PaintingDataDetailPhosphatingItems { get; set; }
        public DbSet<PaintingDataDetailMembraneWeightItem> PaintingDataDetailMembraneWeightItems { get; set; }
        public DbSet<PaintingDataDetailPRatioItem> PaintingDataDetailPRatioItems { get; set; }
        public DbSet<PaintingDataDetailElectrophoreticItem> PaintingDataDetailElectrophoreticItems { get; set; }
        public DbSet<PaintingDataDetailHardnessItem> PaintingDataDetailHardnessItems { get; set; }
        public DbSet<PaintingDataDetailRoughnessItem> PaintingDataDetailRoughnessItems { get; set; }
        public DbSet<PaintingDataDetailHitResistanceItem> PaintingDataDetailHitResistanceItems { get; set; }
        public DbSet<PaintingDataDetailAdhesionItem> PaintingDataDetailAdhesionItems { get; set; }
        public DbSet<PaintingDataDetailDampHeatItem> PaintingDataDetailDampHeatItems { get; set; }
        public DbSet<FLDDataDetail> FLDDataDetails { get; set; }
        public DbSet<FLDDataDetailItem> FLDDataDetailItems { get; set; }
        public DbSet<ReboundDataDetail> ReboundDataDetails { get; set; }
        public DbSet<ReboundDataDetailItem> ReboundDataDetailItems { get; set; }
        public DbSet<ReboundDataDetailItem2> ReboundDataDetailItems2 { get; set; }
        public DbSet<ReboundDataDetailItem3> ReboundDataDetailItems3 { get; set; }
        public DbSet<BakeHardeningDataDetail> BakeHardeningDataDetails { get; set; }
        public DbSet<BakeHardeningDataDetailItem> BakeHardeningDataDetailItems { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside MaterialSystemDbContextModelCreatingExtensions.ConfigureMaterialSystem
         */

        public MaterialSystemDbContext(DbContextOptions<MaterialSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable("AbpUsers"); //Sharing the same table "AbpUsers" with the IdentityUser
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                //Moved customization to a method so we can share it with the MaterialSystemMigrationsDbContext class
                b.ConfigureCustomUserProperties();
            });

            /* Configure your own tables/entities inside the ConfigureMaterialSystem method */

            builder.ConfigureMaterialSystem();
        }
    }
}
