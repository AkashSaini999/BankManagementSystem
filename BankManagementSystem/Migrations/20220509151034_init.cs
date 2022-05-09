using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankManagementSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    EmailId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Pan = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    ContactNo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updateddate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    LoanType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    LoanAmount = table.Column<double>(type: "float", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ROI = table.Column<float>(type: "real", nullable: false),
                    LoanDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loans_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
