using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class 数据库材料表结构调整 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Material_Materials");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Material_Materials");

            migrationBuilder.DropColumn(
                name: "MaxModel",
                table: "Material_Materials");

            migrationBuilder.DropColumn(
                name: "MinModel",
                table: "Material_Materials");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_WeldingDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_WeldingDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_SurfacePropertyDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_SurfacePropertyDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_StaticTensionDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_StaticTensionDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_ReboundDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_ReboundDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_ProhibitedSubstanceDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_ProhibitedSubstanceDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_PhysicalPerformanceDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_PhysicalPerformanceDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_PaintingDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_PaintingDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_MetallographicDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_MetallographicDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Model",
                table: "Material_Materials",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_LowCycleFatigueDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_LowCycleFatigueDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_HydrogenInducedDelayedFractureDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_HydrogenInducedDelayedFractureDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_HighSpeedStrechDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_HighSpeedStrechDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_HighCycleFatigueDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_HighCycleFatigueDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_FLDDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_FLDDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_FlangingClaspDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_FlangingClaspDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_DentResistanceDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_DentResistanceDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_CompressDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_CompressDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_ChemicalElementDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_ChemicalElementDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_CementingDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_CementingDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_BendingDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_BendingDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnds",
                table: "Material_BakeHardeningDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dates",
                table: "Material_BakeHardeningDataDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_WeldingDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_WeldingDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_SurfacePropertyDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_SurfacePropertyDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_StaticTensionDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_StaticTensionDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_ReboundDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_ReboundDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_ProhibitedSubstanceDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_ProhibitedSubstanceDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_PhysicalPerformanceDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_PhysicalPerformanceDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_PaintingDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_PaintingDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Material_Materials");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_LowCycleFatigueDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_LowCycleFatigueDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_HydrogenInducedDelayedFractureDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_HydrogenInducedDelayedFractureDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_HighSpeedStrechDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_HighSpeedStrechDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_HighCycleFatigueDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_HighCycleFatigueDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_FLDDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_FLDDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_FlangingClaspDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_FlangingClaspDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_DentResistanceDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_DentResistanceDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_CompressDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_CompressDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_ChemicalElementDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_ChemicalElementDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_CementingDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_CementingDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_BendingDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_BendingDataDetails");

            migrationBuilder.DropColumn(
                name: "DateEnds",
                table: "Material_BakeHardeningDataDetails");

            migrationBuilder.DropColumn(
                name: "Dates",
                table: "Material_BakeHardeningDataDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Material_Materials",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Material_Materials",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxModel",
                table: "Material_Materials",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinModel",
                table: "Material_Materials",
                type: "numeric",
                nullable: true);
        }
    }
}
