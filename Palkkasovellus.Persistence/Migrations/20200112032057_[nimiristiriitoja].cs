using Microsoft.EntityFrameworkCore.Migrations;

namespace Palkkasovellus.Persistence.Migrations
{
    public partial class nimiristiriitoja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ennakonpidatys",
                table: "Maksutapahtumat");

            migrationBuilder.RenameColumn(
                name: "Tyoelakemaksu",
                table: "Maksutapahtumat",
                newName: "Vero");

            migrationBuilder.AddColumn<decimal>(
                name: "Elakemaksuprosentti",
                table: "Maksutapahtumat",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Jasenmaksuprosentti",
                table: "Maksutapahtumat",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Sotumaksuprosentti",
                table: "Maksutapahtumat",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Tyottomyysvakuutusprosentti",
                table: "Maksutapahtumat",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elakemaksuprosentti",
                table: "Maksutapahtumat");

            migrationBuilder.DropColumn(
                name: "Jasenmaksuprosentti",
                table: "Maksutapahtumat");

            migrationBuilder.DropColumn(
                name: "Sotumaksuprosentti",
                table: "Maksutapahtumat");

            migrationBuilder.DropColumn(
                name: "Tyottomyysvakuutusprosentti",
                table: "Maksutapahtumat");

            migrationBuilder.RenameColumn(
                name: "Vero",
                table: "Maksutapahtumat",
                newName: "Tyoelakemaksu");

            migrationBuilder.AddColumn<decimal>(
                name: "Ennakonpidatys",
                table: "Maksutapahtumat",
                type: "Money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
