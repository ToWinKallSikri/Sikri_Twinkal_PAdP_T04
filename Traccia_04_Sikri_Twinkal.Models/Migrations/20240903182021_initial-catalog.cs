using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traccia_04_Sikri_Twinkal.Models.Migrations
{
    /// <inheritdoc />
    public partial class initialcatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipologieRisorse",
                columns: table => new
                {
                    TipologiaRisorsaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipologieRisorse", x => x.TipologiaRisorsaId);
                });

            migrationBuilder.CreateTable(
                name: "Utente",
                columns: table => new
                {
                    UtenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utente", x => x.UtenteId);
                });

            migrationBuilder.CreateTable(
                name: "Risorse",
                columns: table => new
                {
                    RisorsaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipologiaRisorsaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risorse", x => x.RisorsaId);
                    table.ForeignKey(
                        name: "FK_Risorse_TipologieRisorse_TipologiaRisorsaId",
                        column: x => x.TipologiaRisorsaId,
                        principalTable: "TipologieRisorse",
                        principalColumn: "TipologiaRisorsaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prenotazioni",
                columns: table => new
                {
                    PrenotazioneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInizio = table.Column<DateOnly>(type: "date", nullable: false),
                    DataFine = table.Column<DateOnly>(type: "date", nullable: false),
                    UtenteId = table.Column<int>(type: "int", nullable: false),
                    RisorsaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazioni", x => x.PrenotazioneId);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Risorse_RisorsaId",
                        column: x => x.RisorsaId,
                        principalTable: "Risorse",
                        principalColumn: "RisorsaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Utente_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utente",
                        principalColumn: "UtenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_RisorsaId",
                table: "Prenotazioni",
                column: "RisorsaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_UtenteId",
                table: "Prenotazioni",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Risorse_TipologiaRisorsaId",
                table: "Risorse",
                column: "TipologiaRisorsaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenotazioni");

            migrationBuilder.DropTable(
                name: "Risorse");

            migrationBuilder.DropTable(
                name: "Utente");

            migrationBuilder.DropTable(
                name: "TipologieRisorse");
        }
    }
}
