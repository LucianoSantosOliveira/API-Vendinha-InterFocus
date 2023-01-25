using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVendinhaInterFocus.Migrations
{
    /// <inheritdoc />
    public partial class fiasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Divida",
                columns: table => new
                {
                    DividaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorDivida = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstaPaga = table.Column<bool>(type: "bit", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDePagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divida", x => x.DividaId);
                    table.ForeignKey(
                        name: "FK_Divida_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Divida_ClienteId",
                table: "Divida",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Divida");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
