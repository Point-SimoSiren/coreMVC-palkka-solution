using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Palkkasovellus.Persistence.Migrations
{
    public partial class parannuksia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maksuhistoriat");

            migrationBuilder.DropTable(
                name: "Verov");

            migrationBuilder.CreateTable(
                name: "Maksutapahtumat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HenkiloId = table.Column<int>(nullable: false),
                    Kokonimi = table.Column<string>(maxLength: 100, nullable: true),
                    Sotu = table.Column<string>(nullable: true),
                    Maksupaiva = table.Column<DateTime>(nullable: false),
                    Maksukuukausi = table.Column<string>(nullable: true),
                    Veronumero = table.Column<string>(nullable: true),
                    Veroprosentti = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Tuloraja = table.Column<decimal>(type: "Money", nullable: false),
                    Lisaprosentti = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Tuntipalkka = table.Column<decimal>(type: "money", nullable: false),
                    Tuntimaara = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SaannollisetTunnit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Ylityotunnit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SaannolPalkka = table.Column<decimal>(type: "Money", nullable: false),
                    Ylityopalkka = table.Column<decimal>(type: "Money", nullable: false),
                    Ennakonpidatys = table.Column<decimal>(type: "Money", nullable: false),
                    Tyoelakemaksu = table.Column<decimal>(type: "Money", nullable: false),
                    Sosiaaliturvamaksu = table.Column<decimal>(type: "Money", nullable: false),
                    Tyottomyysvakuutus = table.Column<decimal>(type: "Money", nullable: false),
                    Jasenmaksu = table.Column<decimal>(type: "Money", nullable: false),
                    PalkkaYhteensa = table.Column<decimal>(type: "Money", nullable: false),
                    VahennyksetYhteensa = table.Column<decimal>(type: "Money", nullable: false),
                    Nettopalkka = table.Column<decimal>(type: "Money", nullable: false),
                    VeronMaara = table.Column<decimal>(nullable: false),
                    Elakemaksu = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maksutapahtumat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maksutapahtumat_Henkilot_HenkiloId",
                        column: x => x.HenkiloId,
                        principalTable: "Henkilot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maksutapahtumat_HenkiloId",
                table: "Maksutapahtumat",
                column: "HenkiloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maksutapahtumat");

            migrationBuilder.CreateTable(
                name: "Verov",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Verotusvuosi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verov", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maksuhistoriat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ennakonpidatys = table.Column<decimal>(type: "Money", nullable: false),
                    HenkiloId = table.Column<int>(type: "int", nullable: false),
                    Jasenmaksu = table.Column<decimal>(type: "Money", nullable: true),
                    Kokonimi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Lisaprosentti = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    MaksuKuukausi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maksupaiva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nettopalkka = table.Column<decimal>(type: "Money", nullable: false),
                    PalkkaYhteensa = table.Column<decimal>(type: "Money", nullable: false),
                    SaannolPalkka = table.Column<decimal>(type: "Money", nullable: false),
                    SaannollisetTunnit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Sosiaaliturvamaksu = table.Column<decimal>(type: "Money", nullable: false),
                    Sotu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tuloraja = table.Column<decimal>(type: "Money", nullable: false),
                    Tuntimaara = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Tuntipalkka = table.Column<decimal>(type: "money", nullable: false),
                    Tyoelakemaksu = table.Column<decimal>(type: "Money", nullable: false),
                    Tyottomyysvakuutus = table.Column<decimal>(type: "Money", nullable: false),
                    VahennyksetYhteensa = table.Column<decimal>(type: "Money", nullable: false),
                    Veronumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Veroprosentti = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    VerovuosiId = table.Column<int>(type: "int", nullable: false),
                    YlityoPalkka = table.Column<decimal>(type: "Money", nullable: false),
                    Ylityotunnit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maksuhistoriat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maksuhistoriat_Henkilot_HenkiloId",
                        column: x => x.HenkiloId,
                        principalTable: "Henkilot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maksuhistoriat_Verov_VerovuosiId",
                        column: x => x.VerovuosiId,
                        principalTable: "Verov",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maksuhistoriat_HenkiloId",
                table: "Maksuhistoriat",
                column: "HenkiloId");

            migrationBuilder.CreateIndex(
                name: "IX_Maksuhistoriat_VerovuosiId",
                table: "Maksuhistoriat",
                column: "VerovuosiId");
        }
    }
}
