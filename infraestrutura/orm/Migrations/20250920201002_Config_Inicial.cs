using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoParaEstacionamento.Infraestrutura.ORM.Migrations
{
    /// <inheritdoc />
    public partial class Config_Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "CREATE SEQUENCE public.ticket_seq INCREMENT 1 START 1 MINVALUE 1;");

            migrationBuilder.CreateTable(
                name: "Tb_Entrada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ticket = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('public.ticket_seq')"),
                    Veiculo_Placa = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Veiculo_Modelo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Veiculo_Cor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Veiculo_CpfHospede = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Observacoes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DataHoraEntrada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Entrada", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Entrada_Veiculo_Placa",
                table: "Tb_Entrada",
                column: "Veiculo_Placa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Entrada");

            migrationBuilder.Sql(
                "DROP SEQUENCE public.ticket_seq;");
        }
    }
}
