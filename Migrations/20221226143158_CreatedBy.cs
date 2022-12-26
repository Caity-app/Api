using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class CreatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Houses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CreatedById",
                table: "Houses",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Members_CreatedById",
                table: "Houses",
                column: "CreatedById",
                principalTable: "Members",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Members_CreatedById",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_CreatedById",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Houses");
        }
    }
}
