using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lb1.Migrations
{
    /// <inheritdoc />
    public partial class AddCreditAndDeposit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditPlanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditPlanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepositPlanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositPlanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditPlaneId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartAmount = table.Column<double>(type: "float", nullable: false),
                    PercentAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditLists_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditLists_CreditPlanes_CreditPlaneId",
                        column: x => x.CreditPlaneId,
                        principalTable: "CreditPlanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositPlaneId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartAmount = table.Column<double>(type: "float", nullable: false),
                    PercentAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositLists_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositLists_DepositPlanes_DepositPlaneId",
                        column: x => x.DepositPlaneId,
                        principalTable: "DepositPlanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditLists_ClientId",
                table: "CreditLists",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditLists_CreditPlaneId",
                table: "CreditLists",
                column: "CreditPlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositLists_ClientId",
                table: "DepositLists",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositLists_DepositPlaneId",
                table: "DepositLists",
                column: "DepositPlaneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditLists");

            migrationBuilder.DropTable(
                name: "DepositLists");

            migrationBuilder.DropTable(
                name: "CreditPlanes");

            migrationBuilder.DropTable(
                name: "DepositPlanes");
        }
    }
}
