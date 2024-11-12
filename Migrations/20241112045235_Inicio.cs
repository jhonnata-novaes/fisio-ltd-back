using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace fisio_ltd_back.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosBasicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    DataAvaliacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstadoCivil = table.Column<string>(type: "text", nullable: true),
                    Nacionalidade = table.Column<string>(type: "text", nullable: true),
                    Naturalidade = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Peso = table.Column<decimal>(type: "numeric", nullable: true),
                    Altura = table.Column<decimal>(type: "numeric", nullable: true),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    NumeroIdentidade = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Profissao = table.Column<string>(type: "text", nullable: true),
                    DiagnosticoClinico = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBasicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosticoPrognostico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DadosBasicosId = table.Column<int>(type: "integer", nullable: false),
                    DiagnosticoFisio = table.Column<string>(type: "text", nullable: true),
                    PrognosticoFisio = table.Column<string>(type: "text", nullable: true),
                    Quantidade = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticoPrognostico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DadosBasicosId = table.Column<int>(type: "integer", nullable: false),
                    ExamesComplementares = table.Column<string>(type: "text", nullable: true),
                    ExameFisico = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FichasAnamnese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DadosBasicosId = table.Column<int>(type: "integer", nullable: false),
                    Queixa = table.Column<string>(type: "text", nullable: true),
                    HistoriaDoencaAtual = table.Column<string>(type: "text", nullable: true),
                    HistoriaPatologica = table.Column<string>(type: "text", nullable: true),
                    HabitosVida = table.Column<string>(type: "text", nullable: true),
                    HistoriaFamiliar = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasAnamnese", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TratamentoProposto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DadosBasicosId = table.Column<int>(type: "integer", nullable: false),
                    Plano = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentoProposto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TratamentoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DadosBasicosId = table.Column<int>(type: "integer", nullable: false),
                    Finalizado = table.Column<bool>(type: "boolean", nullable: false),
                    Cancelado = table.Column<bool>(type: "boolean", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentoStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamentoStatus_DadosBasicos_DadosBasicosId",
                        column: x => x.DadosBasicosId,
                        principalTable: "DadosBasicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TratamentoStatus_DadosBasicosId",
                table: "TratamentoStatus",
                column: "DadosBasicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosticoPrognostico");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "FichasAnamnese");

            migrationBuilder.DropTable(
                name: "TratamentoProposto");

            migrationBuilder.DropTable(
                name: "TratamentoStatus");

            migrationBuilder.DropTable(
                name: "DadosBasicos");
        }
    }
}
