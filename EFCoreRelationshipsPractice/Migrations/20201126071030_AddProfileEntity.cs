﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreRelationshipsPractice.Migrations
{
    public partial class AddProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileEntitiesId",
                table: "Companies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfileEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RegisteredCapital = table.Column<int>(nullable: false),
                    CertId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ProfileEntitiesId",
                table: "Companies",
                column: "ProfileEntitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ProfileEntity_ProfileEntitiesId",
                table: "Companies",
                column: "ProfileEntitiesId",
                principalTable: "ProfileEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ProfileEntity_ProfileEntitiesId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "ProfileEntity");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ProfileEntitiesId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ProfileEntitiesId",
                table: "Companies");
        }
    }
}
