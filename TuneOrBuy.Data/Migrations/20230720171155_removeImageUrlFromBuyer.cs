using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuneOrBuy.Data.Migrations
{
    public partial class removeImageUrlFromBuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);
        }
    }
}
