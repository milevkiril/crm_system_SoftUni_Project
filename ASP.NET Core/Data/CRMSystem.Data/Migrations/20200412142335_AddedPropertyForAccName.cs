using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMSystem.Data.Migrations
{
    public partial class AddedPropertyForAccName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Deals");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Deals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Deals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DealOwner",
                table: "Deals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "DealOwner",
                table: "Deals");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Deals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
