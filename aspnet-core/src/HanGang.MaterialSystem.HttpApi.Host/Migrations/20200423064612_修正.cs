﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class 修正 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialId",
                table: "Material_MaterialRecommendations",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialRecommendations_MaterialId",
                table: "Material_MaterialRecommendations",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaterialRecommendations_Material_Materials_Materia~",
                table: "Material_MaterialRecommendations",
                column: "MaterialId",
                principalTable: "Material_Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaterialRecommendations_Material_Materials_Materia~",
                table: "Material_MaterialRecommendations");

            migrationBuilder.DropIndex(
                name: "IX_Material_MaterialRecommendations_MaterialId",
                table: "Material_MaterialRecommendations");

            migrationBuilder.AlterColumn<Guid>(
                name: "MaterialId",
                table: "Material_MaterialRecommendations",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
