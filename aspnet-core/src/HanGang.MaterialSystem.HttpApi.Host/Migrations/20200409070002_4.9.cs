using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class _49 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SurfaceQualityGrade",
                table: "Material_SurfacePropertyDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeightRequirement",
                table: "Material_SurfacePropertyCoatingWeights",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Material_Materials",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReelNumber",
                table: "Material_Materials",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RealPlasticStrainHalf",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RealPlasticStressHalf",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Material_SurfacePropertyRoughnessAndPeakDensitys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SurfacePropertyDataDetailId = table.Column<Guid>(nullable: true),
                    RaRequirement = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    AboveRoughness = table.Column<decimal>(nullable: true),
                    AbovePeakDensity = table.Column<decimal>(nullable: true),
                    BelowRoughness = table.Column<decimal>(nullable: true),
                    BelowPeakDensity = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_SurfacePropertyRoughnessAndPeakDensitys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_SurfacePropertyRoughnessAndPeakDensitys_Material_S~",
                        column: x => x.SurfacePropertyDataDetailId,
                        principalTable: "Material_SurfacePropertyDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material_SurfacePropertySizeTolerances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    SurfacePropertyDataDetailId = table.Column<Guid>(nullable: true),
                    SizeRequirement = table.Column<string>(nullable: true),
                    TestCode = table.Column<string>(nullable: true),
                    EdgeThickness1 = table.Column<decimal>(nullable: true),
                    EdgeThickness2 = table.Column<decimal>(nullable: true),
                    EdgeThickness3 = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_SurfacePropertySizeTolerances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_SurfacePropertySizeTolerances_Material_SurfaceProp~",
                        column: x => x.SurfacePropertyDataDetailId,
                        principalTable: "Material_SurfacePropertyDataDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_SurfacePropertyRoughnessAndPeakDensitys_SurfacePro~",
                table: "Material_SurfacePropertyRoughnessAndPeakDensitys",
                column: "SurfacePropertyDataDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SurfacePropertySizeTolerances_SurfacePropertyDataD~",
                table: "Material_SurfacePropertySizeTolerances",
                column: "SurfacePropertyDataDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material_SurfacePropertyRoughnessAndPeakDensitys");

            migrationBuilder.DropTable(
                name: "Material_SurfacePropertySizeTolerances");

            migrationBuilder.DropColumn(
                name: "SurfaceQualityGrade",
                table: "Material_SurfacePropertyDataDetails");

            migrationBuilder.DropColumn(
                name: "WeightRequirement",
                table: "Material_SurfacePropertyCoatingWeights");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Material_Materials");

            migrationBuilder.DropColumn(
                name: "ReelNumber",
                table: "Material_Materials");

            migrationBuilder.DropColumn(
                name: "RealPlasticStrainHalf",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends");

            migrationBuilder.DropColumn(
                name: "RealPlasticStressHalf",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends");
        }
    }
}
