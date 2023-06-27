using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppSqlDataBase.Migrations
{
    /// <inheritdoc />
    public partial class thireedyyy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Auctions",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Auctions");
        }
    }
}
