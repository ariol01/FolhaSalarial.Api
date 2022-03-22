using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Folha.Migrations
{
    public partial class InitialProjetoFolhaSalarial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalarioBruto = table.Column<decimal>(type: "money", nullable: false),
                    DataDeAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescontoNoPlanoDeSaude = table.Column<bool>(type: "bit", nullable: false),
                    DescontoNoPlanoDental = table.Column<bool>(type: "bit", nullable: false),
                    DescontoNoValeTransporte = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracheques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesDeReferencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalDeDescontos = table.Column<decimal>(type: "money", nullable: false),
                    SalarioLiquido = table.Column<decimal>(type: "money", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracheques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracheques_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lancamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "money", nullable: false),
                    ContrachequeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamento_Contracheques_ContrachequeId",
                        column: x => x.ContrachequeId,
                        principalTable: "Contracheques",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracheques_FuncionarioId",
                table: "Contracheques",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Documento",
                table: "Funcionarios",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_ContrachequeId",
                table: "Lancamento",
                column: "ContrachequeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamento");

            migrationBuilder.DropTable(
                name: "Contracheques");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
