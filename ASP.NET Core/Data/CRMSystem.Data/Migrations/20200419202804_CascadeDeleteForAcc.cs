using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMSystem.Data.Migrations
{
    public partial class CascadeDeleteForAcc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Accounts_AccountId",
                table: "Deals");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Accounts_AccountId",
                table: "Deals",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Accounts_AccountId",
                table: "Deals");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Accounts_AccountId",
                table: "Deals",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
