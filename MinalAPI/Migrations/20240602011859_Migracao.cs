using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinalAPI.Migrations
{
    /// <inheritdoc />
    public partial class Migracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localizacao",
                columns: table => new
                {
                    IdLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Latitude = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    Porto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacao", x => x.IdLocalizacao);
                });

            migrationBuilder.CreateTable(
                name: "Navio",
                columns: table => new
                {
                    IdNavio = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TipoNavio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CapacidadeLastro = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navio", x => x.IdNavio);
                });

            migrationBuilder.CreateTable(
                name: "Operacao_lastro",
                columns: table => new
                {
                    IdOperacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoOperacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    QuantidadeAgua = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    OperecaoTimestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IdLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdNavio = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacao_lastro", x => x.IdOperacao);
                    table.ForeignKey(
                        name: "FK_Operacao_lastro_Localizacao_IdLocalizacao",
                        column: x => x.IdLocalizacao,
                        principalTable: "Localizacao",
                        principalColumn: "IdLocalizacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operacao_lastro_Navio_IdNavio",
                        column: x => x.IdNavio,
                        principalTable: "Navio",
                        principalColumn: "IdNavio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitoramento_operacao",
                columns: table => new
                {
                    IdMonitoramento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeMetrica = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ValorMetrica = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    MetricaTimestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    IdNavio = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdOperacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoramento_operacao", x => x.IdMonitoramento);
                    table.ForeignKey(
                        name: "FK_Monitoramento_operacao_Navio_IdNavio",
                        column: x => x.IdNavio,
                        principalTable: "Navio",
                        principalColumn: "IdNavio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monitoramento_operacao_Operacao_lastro_IdOperacao",
                        column: x => x.IdOperacao,
                        principalTable: "Operacao_lastro",
                        principalColumn: "IdOperacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historico_localizacao",
                columns: table => new
                {
                    IdHistorico = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HistoricoTimestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IdLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdNavio = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdMonitoramento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico_localizacao", x => x.IdHistorico);
                    table.ForeignKey(
                        name: "FK_Historico_localizacao_Localizacao_IdLocalizacao",
                        column: x => x.IdLocalizacao,
                        principalTable: "Localizacao",
                        principalColumn: "IdLocalizacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historico_localizacao_Monitoramento_operacao_IdMonitoramento",
                        column: x => x.IdMonitoramento,
                        principalTable: "Monitoramento_operacao",
                        principalColumn: "IdMonitoramento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historico_localizacao_Navio_IdNavio",
                        column: x => x.IdNavio,
                        principalTable: "Navio",
                        principalColumn: "IdNavio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historico_localizacao_IdLocalizacao",
                table: "Historico_localizacao",
                column: "IdLocalizacao");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_localizacao_IdMonitoramento",
                table: "Historico_localizacao",
                column: "IdMonitoramento");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_localizacao_IdNavio",
                table: "Historico_localizacao",
                column: "IdNavio");

            migrationBuilder.CreateIndex(
                name: "IX_Monitoramento_operacao_IdNavio",
                table: "Monitoramento_operacao",
                column: "IdNavio");

            migrationBuilder.CreateIndex(
                name: "IX_Monitoramento_operacao_IdOperacao",
                table: "Monitoramento_operacao",
                column: "IdOperacao");

            migrationBuilder.CreateIndex(
                name: "IX_Operacao_lastro_IdLocalizacao",
                table: "Operacao_lastro",
                column: "IdLocalizacao");

            migrationBuilder.CreateIndex(
                name: "IX_Operacao_lastro_IdNavio",
                table: "Operacao_lastro",
                column: "IdNavio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historico_localizacao");

            migrationBuilder.DropTable(
                name: "Monitoramento_operacao");

            migrationBuilder.DropTable(
                name: "Operacao_lastro");

            migrationBuilder.DropTable(
                name: "Localizacao");

            migrationBuilder.DropTable(
                name: "Navio");
        }
    }
}
