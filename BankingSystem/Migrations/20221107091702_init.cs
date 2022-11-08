using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Accounts",
                columns: table => new
                {
                    AccTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Accounts", x => x.AccTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Atmdtls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    Atmpin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Atmdtls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Checkbookdtls",
                columns: table => new
                {
                    checkbookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Checkbookdtls", x => x.checkbookId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_FundTransfers",
                columns: table => new
                {
                    TransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SrcAccountNumber = table.Column<int>(type: "int", nullable: false),
                    DestAccountNumber = table.Column<int>(type: "int", nullable: false),
                    DestAccTypeId = table.Column<int>(type: "int", nullable: false),
                    TransferAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FundTransfers", x => x.TransferId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TransactionMaps",
                columns: table => new
                {
                    TranTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TransactionMaps", x => x.TranTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    AccTypeId = table.Column<int>(type: "int", nullable: false),
                    TranTypeId = table.Column<int>(type: "int", nullable: false),
                    TranDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SecurityQuestion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SecurityAnswer = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AccTypeId = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.AccountNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Accounts");

            migrationBuilder.DropTable(
                name: "tbl_Atmdtls");

            migrationBuilder.DropTable(
                name: "tbl_Checkbookdtls");

            migrationBuilder.DropTable(
                name: "tbl_FundTransfers");

            migrationBuilder.DropTable(
                name: "tbl_TransactionMaps");

            migrationBuilder.DropTable(
                name: "tbl_Transactions");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
