using Microsoft.EntityFrameworkCore.Migrations;

namespace Palkkasovellus.Persistence.Migrations
{
    public partial class UpdatedHenkilo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Puhelin",
                table: "Henkilot",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Puhelin",
                table: "Henkilot");
        }
    }
}
