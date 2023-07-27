using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuneOrBuy.Data.Migrations
{
    public partial class dropEquipmentAndServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentAndService_Cars_CarId",
                table: "EquipmentAndService");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentAndService_CarId",
                table: "EquipmentAndService");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "EquipmentAndService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "EquipmentAndService",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAndService_CarId",
                table: "EquipmentAndService",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentAndService_Cars_CarId",
                table: "EquipmentAndService",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
