using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QyonAdventureWorks.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competidores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "VARCHAR(150)", maxLength: 40, nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    TemperaturaMediCorpo = table.Column<decimal>(nullable: false),
                    Peso = table.Column<decimal>(nullable: false),
                    Altura = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoCorridas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompetidorId = table.Column<int>(nullable: false),
                    PistaCorridaId = table.Column<int>(nullable: false),
                    DataCorrida = table.Column<DateTime>(nullable: false),
                    TempoGasto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCorridas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PistaCorridas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descrição = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PistaCorridas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competidores");

            migrationBuilder.DropTable(
                name: "HistoricoCorridas");

            migrationBuilder.DropTable(
                name: "PistaCorridas");
        }
    }
}
