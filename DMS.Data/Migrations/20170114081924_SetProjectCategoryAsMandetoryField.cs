using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Data.Migrations
{
    public partial class SetProjectCategoryAsMandetoryField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectCategory_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectCategory",
                table: "ProjectCategory");

            migrationBuilder.RenameTable(
                name: "ProjectCategory",
                newName: "ProjectCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCategoryId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectCategories",
                table: "ProjectCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategories_ShortDescription",
                table: "ProjectCategories",
                column: "ShortDescription",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectCategories_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId",
                principalTable: "ProjectCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectCategories_ProjectCategoryId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectCategories",
                table: "ProjectCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProjectCategories_ShortDescription",
                table: "ProjectCategories");

            migrationBuilder.RenameTable(
                name: "ProjectCategories",
                newName: "ProjectCategory");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCategoryId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectCategory",
                table: "ProjectCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectCategory_ProjectCategoryId",
                table: "Projects",
                column: "ProjectCategoryId",
                principalTable: "ProjectCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
