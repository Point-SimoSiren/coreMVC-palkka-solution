using Microsoft.EntityFrameworkCore.Migrations;

namespace Palkkasovellus.Persistence.Migrations
{
    public partial class doubleArvoiksi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "VeronMaara",
                table: "Maksutapahtumat",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Elakemaksu",
                table: "Maksutapahtumat",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "VeronMaara",
                table: "Maksutapahtumat",
                type: "double(18,2)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Elakemaksu",
                table: "Maksutapahtumat",
                type: "double(18,2)",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
