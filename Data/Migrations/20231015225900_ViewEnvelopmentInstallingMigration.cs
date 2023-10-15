using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opuestos_por_el_Vertice.Migrations
{
    public partial class ViewEnvelopmentInstallingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreClass",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreClass",
                table: "Posts");
        }
    }
}
