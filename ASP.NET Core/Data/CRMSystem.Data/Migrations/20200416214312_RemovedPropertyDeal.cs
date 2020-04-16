using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMSystem.Data.Migrations
{
    public partial class RemovedPropertyDeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DealId",
                table: "Deals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DealId",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
