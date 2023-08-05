using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuneOrBuy.Data.Migrations
{
    public partial class ChangeServicesTypeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Services",
                table: "CarServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Services",
                table: "CarServices");
        }
    }
}
