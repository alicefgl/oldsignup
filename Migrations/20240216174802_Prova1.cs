using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace foglietta.alice._5i.ProvaDb.Migrations
{
    /// <inheritdoc />
    public partial class Prova1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenotazioni",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cognome = table.Column<string>(type: "TEXT", nullable: true),
                    DataDiNascita = table.Column<DateTime>(type: "TEXT", nullable: false),
                    _Sesso = table.Column<int>(type: "INTEGER", nullable: false),
                    _Ruolo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazioni", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Prodotti",
                columns: table => new
                {
                    _NomeP = table.Column<int>(type: "INTEGER", nullable: false),
                    quantita = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotti", x => x._NomeP);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenotazioni");

            migrationBuilder.DropTable(
                name: "Prodotti");
        }
    }
}
