using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class swetnumestring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Swet",
                table: "Material_SecondaryWorkingEmbrittlementDataDetailItems",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Swet",
                table: "Material_SecondaryWorkingEmbrittlementDataDetailItems",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
