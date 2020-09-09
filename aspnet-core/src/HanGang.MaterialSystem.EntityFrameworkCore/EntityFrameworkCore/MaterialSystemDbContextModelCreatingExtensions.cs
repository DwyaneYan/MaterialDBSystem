using HanGang.MaterialSystem.DemoManagement;
using HanGang.MaterialSystem.Entities;
using HanGang.MaterialSystem.Entities.Rbac;
using HanGang.MaterialSystem.Entities.TrialDataDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users;

namespace HanGang.MaterialSystem.EntityFrameworkCore
{
    public static class MaterialSystemDbContextModelCreatingExtensions
    {
        public static void ConfigureMaterialSystem(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.Entity<Role>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(Role) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<RoleResource>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(RoleResource) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<TrialCategory>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(TrialCategory) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<TrialDetailGroup>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(TrialDetailGroup) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<TrialDetailShowType>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(TrialDetailShowType) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<UserRole>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(UserRole) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<User>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(User) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<DemoProject>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(DemoProject) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<DemoUnitProject>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(DemoUnitProject) + "s");
                b.ConfigureCreationTime();
            });
            builder.Entity<TypicalPart>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(TypicalPart) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<Manufactory>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(Manufactory) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<Trial>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(Trial) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<Material>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(Material) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<MaterialRecommendation>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(MaterialRecommendation) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<ApplicationCase>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(ApplicationCase) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<MaterialTrial>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(MaterialTrial) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<MaterialTrialData>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(MaterialTrialData) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<StaticTensionDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(StaticTensionDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<StaticTensionDataDetailRequirement>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(StaticTensionDataDetailRequirement) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<StaticTensionDataDetailStressStrain>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(StaticTensionDataDetailStressStrain) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<BendingDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(BendingDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<CompressDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(CompressDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<HighSpeedStrechDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(HighSpeedStrechDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<HighSpeedStrechDataDetailStressStrain>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(HighSpeedStrechDataDetailStressStrain) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<HighSpeedStrechDataDetailStressStrainExtend>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(HighSpeedStrechDataDetailStressStrainExtend) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<LowCycleFatigueDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(LowCycleFatigueDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });

            builder.Entity<LowCycleFatigueDataDetailItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(LowCycleFatigueDataDetailItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });

            builder.Entity<HighCycleFatigueDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(HighCycleFatigueDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<HighCycleFatigueDataDetailItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(HighCycleFatigueDataDetailItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<MetallographicDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(MetallographicDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PhysicalPerformanceDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PhysicalPerformanceDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PhysicalPerformanceDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PhysicalPerformanceDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PhysicalPerformanceDataDetailThermalExpansion>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PhysicalPerformanceDataDetailThermalExpansion) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PhysicalPerformanceDataDetailThermalConductivity>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PhysicalPerformanceDataDetailThermalConductivity) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<ChemicalElementDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(ChemicalElementDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<ProhibitedSubstanceDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(ProhibitedSubstanceDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<SurfacePropertyDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(SurfacePropertyDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<SurfacePropertyCoatingWeight>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(SurfacePropertyCoatingWeight) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<SurfacePropertyRoughness>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(SurfacePropertyRoughness) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<SurfacePropertyRoughnessAndPeakDensity>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(SurfacePropertyRoughnessAndPeakDensity) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<SurfacePropertySizeTolerance>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(SurfacePropertySizeTolerance) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<DentResistanceDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(DentResistanceDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            
            builder.Entity<SecondaryWorkingEmbrittlementDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(SecondaryWorkingEmbrittlementDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<SecondaryWorkingEmbrittlementDataDetailItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(SecondaryWorkingEmbrittlementDataDetailItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<FlangingClaspDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(FlangingClaspDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<HydrogenInducedDelayedFractureDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(HydrogenInducedDelayedFractureDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<HydrogenInducedDelayedFractureDataDetailItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(HydrogenInducedDelayedFractureDataDetailItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<WeldingDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(WeldingDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<WeldingDataDetailItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(WeldingDataDetailItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<CementingDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(CementingDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PaintingDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PaintingDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PaintingDataDetailPhosphatingItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PaintingDataDetailPhosphatingItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PaintingDataDetailMembraneWeightItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PaintingDataDetailMembraneWeightItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PaintingDataDetailPRatioItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PaintingDataDetailPRatioItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PaintingDataDetailElectrophoreticItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PaintingDataDetailElectrophoreticItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PaintingDataDetailHardnessItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PaintingDataDetailHardnessItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PaintingDataDetailRoughnessItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PaintingDataDetailRoughnessItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PaintingDataDetailHitResistanceItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PaintingDataDetailHitResistanceItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PaintingDataDetailAdhesionItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PaintingDataDetailAdhesionItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<PaintingDataDetailDampHeatItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(PaintingDataDetailDampHeatItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<FLDDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(FLDDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<FLDDataDetailItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(FLDDataDetailItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<ReboundDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(ReboundDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<ReboundDataDetailItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(ReboundDataDetailItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<ReboundDataDetailItem2>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(ReboundDataDetailItem2) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<ReboundDataDetailItem3>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(ReboundDataDetailItem3) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<BakeHardeningDataDetail>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(BakeHardeningDataDetail) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });
            builder.Entity<BakeHardeningDataDetailItem>(b =>
            {
                b.ToTable(CustomerConsts.DefaultDbTablePrefix + nameof(BakeHardeningDataDetailItem) + "s");
                b.ConfigureFullAuditedAggregateRoot();
            });

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(MaterialSystemConsts.DbTablePrefix + "YourEntities", MaterialSystemConsts.DbSchema);

            //    //...
            //});
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser : class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}