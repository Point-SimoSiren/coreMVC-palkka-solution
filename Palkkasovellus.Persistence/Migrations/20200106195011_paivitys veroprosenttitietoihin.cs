using Microsoft.EntityFrameworkCore.Migrations;

namespace Palkkasovellus.Persistence.Migrations
{
    public partial class paivitysveroprosenttitietoihin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Lisaprosentti",
                table: "Maksuhistoriat",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Tuloraja",
                table: "Maksuhistoriat",
                type: "Money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Veroprosentti",
                table: "Maksuhistoriat",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lisaprosentti",
                table: "Maksuhistoriat");

            migrationBuilder.DropColumn(
                name: "Tuloraja",
                table: "Maksuhistoriat");

            migrationBuilder.DropColumn(
                name: "Veroprosentti",
                table: "Maksuhistoriat");
        }
    }
}
