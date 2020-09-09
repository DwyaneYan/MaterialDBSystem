using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class jlgladdorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_StaticTensionDataDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsertOrder",
                table: "Material_HighSpeedStrechDataDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_StaticTensionDataDetails");

            migrationBuilder.DropColumn(
                name: "InsertOrder",
                table: "Material_HighSpeedStrechDataDetails");
        }
    }
}
