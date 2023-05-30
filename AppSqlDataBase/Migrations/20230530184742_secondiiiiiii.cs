using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppSqlDataBase.Migrations
{
    /// <inheritdoc />
    public partial class secondiiiiiii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentByCostumer",
                table: "Auctions");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "DirectOrders",
                newName: "SellerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidAt",
                table: "DirectOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "Auctions",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentAcceptedAt",
                table: "Auctions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentDeletedAt",
                table: "Auctions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Auctions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HasMedal",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAt",
                table: "DirectOrders");

            migrationBuilder.DropColumn(
                name: "CommentAcceptedAt",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "CommentDeletedAt",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Auctions");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "DirectOrders",
                newName: "CustomerId");

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "Auctions",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<string>(
                name: "CommentByCostumer",
                table: "Auctions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HasMedal",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
