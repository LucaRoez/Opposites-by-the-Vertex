using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opuestos_por_el_Vertice.Migrations
{
    public partial class AddingImageAltAttributeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Albums");
        }
    }
}
