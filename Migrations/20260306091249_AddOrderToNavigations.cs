using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dropbox_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderToNavigations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Navigations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Navigations",
                keyColumn: "Id",
                keyValue: "deleted",
                column: "Order",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Navigations",
                keyColumn: "Id",
                keyValue: "file-requests",
                column: "Order",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Navigations",
                keyColumn: "Id",
                keyValue: "home",
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Navigations",
                keyColumn: "Id",
                keyValue: "my-files",
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Navigations",
                keyColumn: "Id",
                keyValue: "shared",
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Navigations",
                keyColumn: "Id",
                keyValue: "starred",
                column: "Order",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Navigations");
        }
    }
}
