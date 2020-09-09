using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class alltrialaddInertOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_WeldingDataDetailItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_SurfacePropertySizeTolerances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_SurfacePropertyRoughnesss",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_SurfacePropertyRoughnessAndPeakDensitys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_SurfacePropertyCoatingWeights",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_StaticTensionDataDetailStressStrains",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_SecondaryWorkingEmbrittlementDataDetailItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_ReboundDataDetailItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_ReboundDataDetailItem3s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_ReboundDataDetailItem2s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PhysicalPerformanceDataDetailThermalExpansions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PhysicalPerformanceDataDetailThermalConductivitys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailRoughnessItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailPRatioItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailPhosphatingItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailMembraneWeightItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailHitResistanceItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailHardnessItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailElectrophoreticItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailDampHeatItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailAdhesionItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_LowCycleFatigueDataDetailItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_HydrogenInducedDelayedFractureDataDetailItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_HighSpeedStrechDataDetailStressStrains",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_HighCycleFatigueDataDetailItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_FLDDataDetailItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_ChemicalElementDataDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_BakeHardeningDataDetailItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_WeldingDataDetailItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_SurfacePropertySizeTolerances");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_SurfacePropertyRoughnesss");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_SurfacePropertyRoughnessAndPeakDensitys");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_SurfacePropertyCoatingWeights");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_StaticTensionDataDetailStressStrains");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_SecondaryWorkingEmbrittlementDataDetailItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_ReboundDataDetailItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_ReboundDataDetailItem3s");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_ReboundDataDetailItem2s");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PhysicalPerformanceDataDetailThermalExpansions");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PhysicalPerformanceDataDetailThermalConductivitys");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailRoughnessItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailPRatioItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailPhosphatingItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailMembraneWeightItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailHitResistanceItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailHardnessItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailElectrophoreticItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailDampHeatItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_PaintingDataDetailAdhesionItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_LowCycleFatigueDataDetailItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_HydrogenInducedDelayedFractureDataDetailItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_HighSpeedStrechDataDetailStressStrains");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_HighCycleFatigueDataDetailItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_FLDDataDetailItems");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_ChemicalElementDataDetails");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_BakeHardeningDataDetailItems");
        }
    }
}
