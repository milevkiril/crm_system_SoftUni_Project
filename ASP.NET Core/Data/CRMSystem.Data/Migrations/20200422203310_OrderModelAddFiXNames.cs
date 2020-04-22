using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMSystem.Data.Migrations
{
    public partial class OrderModelAddFiXNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deals_dealId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_productId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Orders",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Orders",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "dealId",
                table: "Orders",
                newName: "DealId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_productId",
                table: "Orders",
                newName: "IX_Orders_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_dealId",
                table: "Orders",
                newName: "IX_Orders_DealId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IsDeleted",
                table: "Orders",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deals_DealId",
                table: "Orders",
                column: "DealId",
                principalTable: "Deals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deals_DealId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Orders",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Orders",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "DealId",
                table: "Orders",
                newName: "dealId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                newName: "IX_Orders_productId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DealId",
                table: "Orders",
                newName: "IX_Orders_dealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deals_dealId",
                table: "Orders",
                column: "dealId",
                principalTable: "Deals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_productId",
                table: "Orders",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
