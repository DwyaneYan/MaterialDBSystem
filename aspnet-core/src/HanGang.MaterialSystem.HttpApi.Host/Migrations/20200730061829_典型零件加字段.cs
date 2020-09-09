using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class 典型零件加字段 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Material_TypicalParts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "directoryId",
                table: "Material_TypicalParts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Material_TypicalParts");

            migrationBuilder.DropColumn(
                name: "directoryId",
                table: "Material_TypicalParts");
        }
    }
}
