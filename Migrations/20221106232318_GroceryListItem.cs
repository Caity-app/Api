using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class GroceryListItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryListItem_Houses_HouseId",
                table: "GroceryListItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroceryListItem",
                table: "GroceryListItem");

            migrationBuilder.DropIndex(
                name: "IX_GroceryListItem_HouseId",
                table: "GroceryListItem");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "GroceryListItem");

            migrationBuilder.RenameTable(
                name: "GroceryListItem",
                newName: "GroceryListItems");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "GroceryListItems",
                table: "Houses",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroceryListItems",
                table: "GroceryListItems",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroceryListItems",
                table: "GroceryListItems");

            migrationBuilder.DropColumn(
                name: "GroceryListItems",
                table: "Houses");

            migrationBuilder.RenameTable(
                name: "GroceryListItems",
                newName: "GroceryListItem");

            migrationBuilder.AddColumn<Guid>(
                name: "HouseId",
                table: "GroceryListItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroceryListItem",
                table: "GroceryListItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryListItem_HouseId",
                table: "GroceryListItem",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryListItem_Houses_HouseId",
                table: "GroceryListItem",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id");
        }
    }
}
