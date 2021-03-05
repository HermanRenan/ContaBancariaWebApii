using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoBanco.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankCode = table.Column<int>(nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    AgencyNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    Cpf_Cnpj = table.Column<string>(type: "varchar(30)", nullable: false),
                    ClientName = table.Column<string>(type: "varchar(600)", nullable: false),
                    Status = table.Column<string>(type: "varchar(100)", nullable: true),
                    OpeningDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");
        }
    }
}
