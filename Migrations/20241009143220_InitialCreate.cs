using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace fisio_ltd_back.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstadoCivil = table.Column<string>(type: "text", nullable: false),
                    Nacionalidade = table.Column<string>(type: "text", nullable: false),
                    Naturalidade = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Peso = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    Altura = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    NumeroIdentidade = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Profissao = table.Column<string>(type: "text", nullable: false),
                    DiagnosticoClinico = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBasicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosticosPrognosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    DiagnosticoFisio = table.Column<string>(type: "text", nullable: false),
                    PrognosticoFisio = table.Column<string>(type: "text", nullable: false),
                    QuantidadeAtendimentos = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticosPrognosticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagnosticosPrognosticos_DadosBasicos_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "DadosBasicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    ExamesComplementares = table.Column<string>(type: "text", nullable: false),
                    ExameFisicoFuncional = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exames_DadosBasicos_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "DadosBasicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichasAnamnese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    Queixa = table.Column<string>(type: "text", nullable: false),
                    HistoriaDoencaAtual = table.Column<string>(type: "text", nullable: false),
                    HistoriaPatologica = table.Column<string>(type: "text", nullable: false),
                    HabitosVida = table.Column<string>(type: "text", nullable: false),
                    HistoriaFamiliar = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasAnamnese", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichasAnamnese_DadosBasicos_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "DadosBasicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TratamentosPropostos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    PlanoTeraputico = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamentosPropostos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamentosPropostos_DadosBasicos_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "DadosBasicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticosPrognosticos_PacienteId",
                table: "DiagnosticosPrognosticos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_PacienteId",
                table: "Exames",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasAnamnese_PacienteId",
                table: "FichasAnamnese",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamentosPropostos_PacienteId",
                table: "TratamentosPropostos",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosticosPrognosticos");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "FichasAnamnese");

            migrationBuilder.DropTable(
                name: "TratamentosPropostos");

            migrationBuilder.DropTable(
                name: "DadosBasicos");
        }
    }
}
