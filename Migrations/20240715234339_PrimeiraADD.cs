using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaCasamento.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraADD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convidados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Confirmacao = table.Column<bool>(type: "bit", nullable: false),
                    NomeConvidado = table.Column<string>(name: "Nome Convidado", type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Aniversario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Familia = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    TelefoneConvidado = table.Column<string>(name: "Telefone Convidado", type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convidados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noivos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCasamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeNoivoa = table.Column<string>(name: "Nome Noivo(a)", type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Aniversario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Familia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneNoivoa = table.Column<string>(name: "Telefone Noivo(a)", type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    EmailNoivoa = table.Column<string>(name: "Email Noivo(a)", type: "NVARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Padrinhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomePadrinho = table.Column<string>(name: "Nome Padrinho", type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Aniversario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Familia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonePadrinho = table.Column<string>(name: "Telefone Padrinho", type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padrinhos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Convidados");

            migrationBuilder.DropTable(
                name: "Noivos");

            migrationBuilder.DropTable(
                name: "Padrinhos");
        }
    }
}
