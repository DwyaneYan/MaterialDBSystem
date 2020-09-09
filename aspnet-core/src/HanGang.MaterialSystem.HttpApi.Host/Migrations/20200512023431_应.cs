using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class 应 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material_ApplicationCases",
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
                    Remark = table.Column<string>(nullable: true),
                    MaterialId = table.Column<Guid>(nullable: true),
                    VehicleType = table.Column<string>(nullable: true),
                    Breif = table.Column<string>(nullable: true),
                    SuppliedPart = table.Column<string>(nullable: true),
                    Requirement = table.Column<string>(nullable: true),
                    FileString = table.Column<string>(nullable: true),
                    FileKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_ApplicationCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_ApplicationCases_Material_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material_Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_ApplicationCases_MaterialId",
                table: "Material_ApplicationCases",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material_ApplicationCases");
        }
    }
}
