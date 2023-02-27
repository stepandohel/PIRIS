using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lb1.Migrations
{
    /// <inheritdoc />
    public partial class addATM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "CreditLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditLists_CreditCardId",
                table: "CreditLists",
                column: "CreditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditLists_CreditCards_CreditCardId",
                table: "CreditLists",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditLists_CreditCards_CreditCardId",
                table: "CreditLists");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_CreditLists_CreditCardId",
                table: "CreditLists");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "CreditLists");
        }
    }
}
