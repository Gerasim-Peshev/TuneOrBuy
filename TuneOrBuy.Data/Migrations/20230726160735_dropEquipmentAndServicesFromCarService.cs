using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuneOrBuy.Data.Migrations
{
    public partial class dropEquipmentAndServicesFromCarService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentAndService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentAndService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentAndService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentAndService_CarServices_CarServiceId",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentAndService_CarServiceId",
                table: "EquipmentAndService",
                column: "CarServiceId");
        }
    }
}
