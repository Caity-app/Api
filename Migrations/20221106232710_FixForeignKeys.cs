using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class FixForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Houses",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "GroceryListItems",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "Members",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "GroceryItemId",
                table: "GroceryListItems");

            migrationBuilder.AddColumn<Guid>(
                name: "HouseId",
                table: "GroceryListItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "GroceryListItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HouseMember",
                columns: table => new
                {
                    HousesId = table.Column<Guid>(type: "uuid", nullable: false),
                    MembersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseMember", x => new { x.HousesId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_HouseMember_Houses_HousesId",
                        column: x => x.HousesId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroceryListItems_HouseId",
                table: "GroceryListItems",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryListItems_ItemId",
                table: "GroceryListItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseMember_MembersId",
                table: "HouseMember",
                column: "MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryListItems_GroceryItems_ItemId",
                table: "GroceryListItems",
                column: "ItemId",
                principalTable: "GroceryItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryListItems_Houses_HouseId",
                table: "GroceryListItems",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryListItems_GroceryItems_ItemId",
                table: "GroceryListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryListItems_Houses_HouseId",
                table: "GroceryListItems");

            migrationBuilder.DropTable(
                name: "HouseMember");

            migrationBuilder.DropIndex(
                name: "IX_GroceryListItems_HouseId",
                table: "GroceryListItems");

            migrationBuilder.DropIndex(
                name: "IX_GroceryListItems_ItemId",
                table: "GroceryListItems");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "GroceryListItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "GroceryListItems");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "Houses",
                table: "Members",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "GroceryListItems",
                table: "Houses",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "Members",
                table: "Houses",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroceryItemId",
                table: "GroceryListItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
