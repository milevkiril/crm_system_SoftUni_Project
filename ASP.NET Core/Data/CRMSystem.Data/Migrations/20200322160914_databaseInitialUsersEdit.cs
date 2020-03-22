using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMSystem.Data.Migrations
{
    public partial class databaseInitialUsersEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Deals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Deals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_ApplicationUserId",
                table: "Deals",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_AspNetUsers_ApplicationUserId",
                table: "Deals",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_AspNetUsers_ApplicationUserId",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_ApplicationUserId",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Deals");
        }
    }
}
