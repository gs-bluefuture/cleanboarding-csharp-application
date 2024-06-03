using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinalAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    IdLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    Porto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.IdLocalizacao);
                });

            migrationBuilder.CreateTable(
                name: "Navios",
                columns: table => new
                {
                    IdNavio = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoNavio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CapacidadeLastro = table.Column<double>(type: "BINARY_DOUBLE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navios", x => x.IdNavio);
                });

            migrationBuilder.CreateTable(
                name: "OperacoesLastro",
                columns: table => new
                {
                    IdOperacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LocalizacaoIdLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NavioIdNavio = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoOperacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    QuantidadeAgua = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    OperecaoTimestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacoesLastro", x => new { x.IdOperacao, x.LocalizacaoIdLocalizacao });
                    table.ForeignKey(
                        name: "FK_OperacoesLastro_Localizacoes_LocalizacaoIdLocalizacao",
                        column: x => x.LocalizacaoIdLocalizacao,
                        principalTable: "Localizacoes",
                        principalColumn: "IdLocalizacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperacoesLastro_Navios_NavioIdNavio",
                        column: x => x.NavioIdNavio,
                        principalTable: "Navios",
                        principalColumn: "IdNavio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonitoramentosOperacao",
                columns: table => new
                {
                    IdMonitoramento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OperacaoLastroIdOperacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OperacaoLastroLocalizacaoIdLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NavioIdNavio = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NomeMetrica = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ValorMetrica = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    MetricaTimestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoramentosOperacao", x => new { x.IdMonitoramento, x.OperacaoLastroIdOperacao, x.OperacaoLastroLocalizacaoIdLocalizacao });
                    table.ForeignKey(
                        name: "FK_MonitoramentosOperacao_Navios_NavioIdNavio",
                        column: x => x.NavioIdNavio,
                        principalTable: "Navios",
                        principalColumn: "IdNavio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonitoramentosOperacao_OperacoesLastro_OperacaoLastroIdOperacao_OperacaoLastroLocalizacaoIdLocalizacao",
                        columns: x => new { x.OperacaoLastroIdOperacao, x.OperacaoLastroLocalizacaoIdLocalizacao },
                        principalTable: "OperacoesLastro",
                        principalColumns: new[] { "IdOperacao", "LocalizacaoIdLocalizacao" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricosLocalizacao",
                columns: table => new
                {
                    LocalizacaoIdLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdHistorico = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NavioIdNavio = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    HistoricoTimestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MonitoramentoOperacaoIdMonitoramento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MonitoramentoOperacaoOperacaoLastroIdOperacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MonitoramentoOperacaoOperacaoLastroLocalizacaoIdLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosLocalizacao", x => new { x.LocalizacaoIdLocalizacao, x.IdHistorico, x.NavioIdNavio });
                    table.ForeignKey(
                        name: "FK_HistoricosLocalizacao_Localizacoes_LocalizacaoIdLocalizacao",
                        column: x => x.LocalizacaoIdLocalizacao,
                        principalTable: "Localizacoes",
                        principalColumn: "IdLocalizacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricosLocalizacao_MonitoramentosOperacao_MonitoramentoOperacaoIdMonitoramento_MonitoramentoOperacaoOperacaoLastroIdOpera~",
                        columns: x => new { x.MonitoramentoOperacaoIdMonitoramento, x.MonitoramentoOperacaoOperacaoLastroIdOperacao, x.MonitoramentoOperacaoOperacaoLastroLocalizacaoIdLocalizacao },
                        principalTable: "MonitoramentosOperacao",
                        principalColumns: new[] { "IdMonitoramento", "OperacaoLastroIdOperacao", "OperacaoLastroLocalizacaoIdLocalizacao" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricosLocalizacao_Navios_NavioIdNavio",
                        column: x => x.NavioIdNavio,
                        principalTable: "Navios",
                        principalColumn: "IdNavio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosLocalizacao_MonitoramentoOperacaoIdMonitoramento_MonitoramentoOperacaoOperacaoLastroIdOperacao_MonitoramentoOperac~",
                table: "HistoricosLocalizacao",
                columns: new[] { "MonitoramentoOperacaoIdMonitoramento", "MonitoramentoOperacaoOperacaoLastroIdOperacao", "MonitoramentoOperacaoOperacaoLastroLocalizacaoIdLocalizacao" });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosLocalizacao_NavioIdNavio",
                table: "HistoricosLocalizacao",
                column: "NavioIdNavio");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoramentosOperacao_NavioIdNavio",
                table: "MonitoramentosOperacao",
                column: "NavioIdNavio");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoramentosOperacao_OperacaoLastroIdOperacao_OperacaoLastroLocalizacaoIdLocalizacao",
                table: "MonitoramentosOperacao",
                columns: new[] { "OperacaoLastroIdOperacao", "OperacaoLastroLocalizacaoIdLocalizacao" });

            migrationBuilder.CreateIndex(
                name: "IX_OperacoesLastro_LocalizacaoIdLocalizacao",
                table: "OperacoesLastro",
                column: "LocalizacaoIdLocalizacao");

            migrationBuilder.CreateIndex(
                name: "IX_OperacoesLastro_NavioIdNavio",
                table: "OperacoesLastro",
                column: "NavioIdNavio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricosLocalizacao");

            migrationBuilder.DropTable(
                name: "MonitoramentosOperacao");

            migrationBuilder.DropTable(
                name: "OperacoesLastro");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Navios");
        }
    }
}
