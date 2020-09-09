using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class 图片文档字修 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_WeldingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_WeldingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_WeldingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_SurfacePropertyDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_SurfacePropertyDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_SurfacePropertyDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_StaticTensionDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_StaticTensionDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_StaticTensionDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_ReboundDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_ReboundDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_ReboundDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_ProhibitedSubstanceDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_ProhibitedSubstanceDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_ProhibitedSubstanceDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_PhysicalPerformanceDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_PhysicalPerformanceDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_PhysicalPerformanceDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_PaintingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_PaintingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_PaintingDataDetails");

            migrationBuilder.DropColumn(
                name: "DepthDecarburizationBytes",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "DepthDecarburizationKey",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "DepthDecarburizationString",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "GrainSizeBytes",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "GrainSizeKey",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "GrainSizeString",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "NonMetallicInclusionLevelBytes",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "NonMetallicInclusionLevelKey",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "NonMetallicInclusionLevelString",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "StructurBytes",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "StructureKey",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "StructureString",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_Materials");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_LowCycleFatigueDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_LowCycleFatigueDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_LowCycleFatigueDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_HydrogenInducedDelayedFractureDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_HydrogenInducedDelayedFractureDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_HydrogenInducedDelayedFractureDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_HighSpeedStrechDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_HighSpeedStrechDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_HighSpeedStrechDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_HighCycleFatigueDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_HighCycleFatigueDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_HighCycleFatigueDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_FLDDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_FLDDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_FLDDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_FlangingClaspDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_FlangingClaspDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_FlangingClaspDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_DentResistanceDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_DentResistanceDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_DentResistanceDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_CompressDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_CompressDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_CompressDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_ChemicalElementDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_ChemicalElementDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_ChemicalElementDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_CementingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_CementingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_CementingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_BendingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_BendingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_BendingDataDetails");

            migrationBuilder.DropColumn(
                name: "FileBytes",
                table: "Material_BakeHardeningDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString2",
                table: "Material_BakeHardeningDataDetails");

            migrationBuilder.DropColumn(
                name: "FileString3",
                table: "Material_BakeHardeningDataDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_WeldingDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_WeldingDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_WeldingDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_SurfacePropertyDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_SurfacePropertyDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_SurfacePropertyDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_StaticTensionDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_StaticTensionDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_StaticTensionDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_SecondaryWorkingEmbrittlementDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_ReboundDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_ReboundDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_ReboundDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_ProhibitedSubstanceDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_ProhibitedSubstanceDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_ProhibitedSubstanceDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_PhysicalPerformanceDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_PhysicalPerformanceDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_PhysicalPerformanceDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_PaintingDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_PaintingDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_PaintingDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DepthDecarburizationBytes",
                table: "Material_MetallographicDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepthDecarburizationKey",
                table: "Material_MetallographicDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepthDecarburizationString",
                table: "Material_MetallographicDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_MetallographicDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_MetallographicDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_MetallographicDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "GrainSizeBytes",
                table: "Material_MetallographicDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GrainSizeKey",
                table: "Material_MetallographicDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GrainSizeString",
                table: "Material_MetallographicDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "NonMetallicInclusionLevelBytes",
                table: "Material_MetallographicDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NonMetallicInclusionLevelKey",
                table: "Material_MetallographicDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NonMetallicInclusionLevelString",
                table: "Material_MetallographicDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "StructurBytes",
                table: "Material_MetallographicDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StructureKey",
                table: "Material_MetallographicDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StructureString",
                table: "Material_MetallographicDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_Materials",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_LowCycleFatigueDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_LowCycleFatigueDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_LowCycleFatigueDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_HydrogenInducedDelayedFractureDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_HydrogenInducedDelayedFractureDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_HydrogenInducedDelayedFractureDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_HighSpeedStrechDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_HighSpeedStrechDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_HighSpeedStrechDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_HighCycleFatigueDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_HighCycleFatigueDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_HighCycleFatigueDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_FLDDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_FLDDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_FLDDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_FlangingClaspDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_FlangingClaspDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_FlangingClaspDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_DentResistanceDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_DentResistanceDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_DentResistanceDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_CompressDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_CompressDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_CompressDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_ChemicalElementDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_ChemicalElementDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_ChemicalElementDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_CementingDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_CementingDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_CementingDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_BendingDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_BendingDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_BendingDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBytes",
                table: "Material_BakeHardeningDataDetails",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString2",
                table: "Material_BakeHardeningDataDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileString3",
                table: "Material_BakeHardeningDataDetails",
                type: "text",
                nullable: true);
        }
    }
}
