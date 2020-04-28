using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMSystem.Data.Migrations
{
    public partial class AddPropTAmountDeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Deals",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Deals");
        }
    }
}
