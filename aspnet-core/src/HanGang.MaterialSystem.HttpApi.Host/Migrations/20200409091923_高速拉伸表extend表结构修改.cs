using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class 高速拉伸表extend表结构修改 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_HighSpeedStrechDataDetailStressStrainExtends_Mater~",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends");

            migrationBuilder.DropIndex(
                name: "IX_Material_HighSpeedStrechDataDetailStressStrainExtends_HighS~",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends");

            migrationBuilder.DropColumn(
                name: "HighSpeedStrechDataDetailId",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialTrialDataId",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealPlasticTestTarget",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_HighSpeedStrechDataDetailStressStrainExtends_Mater~",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                column: "MaterialTrialDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_HighSpeedStrechDataDetailStressStrainExtends_Mater~",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                column: "MaterialTrialDataId",
                principalTable: "Material_MaterialTrialDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_HighSpeedStrechDataDetailStressStrainExtends_Mater~",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends");

            migrationBuilder.DropIndex(
                name: "IX_Material_HighSpeedStrechDataDetailStressStrainExtends_Mater~",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends");

            migrationBuilder.DropColumn(
                name: "MaterialTrialDataId",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends");

            migrationBuilder.DropColumn(
                name: "RealPlasticTestTarget",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends");

            migrationBuilder.AddColumn<Guid>(
                name: "HighSpeedStrechDataDetailId",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_HighSpeedStrechDataDetailStressStrainExtends_HighS~",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                column: "HighSpeedStrechDataDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_HighSpeedStrechDataDetailStressStrainExtends_Mater~",
                table: "Material_HighSpeedStrechDataDetailStressStrainExtends",
                column: "HighSpeedStrechDataDetailId",
                principalTable: "Material_HighSpeedStrechDataDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
