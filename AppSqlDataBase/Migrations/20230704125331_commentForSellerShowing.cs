using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppSqlDataBase.Migrations
{
    /// <inheritdoc />
    public partial class commentForSellerShowing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CommentAcceptedAt",
                table: "DirectOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentSubmitedAt",
                table: "DirectOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "OfferSubmitWithPrice",
                table: "Auctions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentAcceptedAt",
                table: "DirectOrders");

            migrationBuilder.DropColumn(
                name: "CommentSubmitedAt",
                table: "DirectOrders");

            migrationBuilder.AlterColumn<decimal>(
                name: "OfferSubmitWithPrice",
                table: "Auctions",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
