using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMSystem.Data.Migrations
{
    public partial class FixProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Information_Contacts_RepresentativeId",
                table: "Information");

            migrationBuilder.DropIndex(
                name: "IX_Information_RepresentativeId",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RepresentativeId",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "DealOwner",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AccountOwner",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Information",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Information_ContactId",
                table: "Information",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Information_Contacts_ContactId",
                table: "Information",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Information_Contacts_ContactId",
                table: "Information");

            migrationBuilder.DropIndex(
                name: "IX_Information_ContactId",
                table: "Information");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Information");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepresentativeId",
                table: "Information",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DealOwner",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountOwner",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Information_RepresentativeId",
                table: "Information",
                column: "RepresentativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Information_Contacts_RepresentativeId",
                table: "Information",
                column: "RepresentativeId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
