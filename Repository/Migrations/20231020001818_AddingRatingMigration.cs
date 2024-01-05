using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opuestos_por_el_Vertice.Migrations
{
    public partial class AddingRatingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Posts");
        }
    }
}
