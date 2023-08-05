using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuneOrBuy.Data.Migrations
{
    public partial class AddFavouriteCarServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId",
                table: "CarServices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_BuyerId",
                table: "CarServices",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarServices_AspNetUsers_BuyerId",
                table: "CarServices",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarServices_AspNetUsers_BuyerId",
                table: "CarServices");

            migrationBuilder.DropIndex(
                name: "IX_CarServices_BuyerId",
                table: "CarServices");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "CarServices");
        }
    }
}
