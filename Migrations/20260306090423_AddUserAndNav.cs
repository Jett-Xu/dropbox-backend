using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dropbox_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndNav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Navigations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Navigations",
                columns: new[] { "Id", "Icon", "Label" },
                values: new object[,]
                {
                    { "deleted", "assets/icons/icon-deleted.svg", "Deleted" },
                    { "file-requests", "assets/icons/icon-file-requests.svg", "Files Requests" },
                    { "home", "assets/icons/icon-home.svg", "Home" },
                    { "my-files", "assets/icons/icon-my-files.svg", "My Files" },
                    { "shared", "assets/icons/icon-shared.svg", "Shared" },
                    { "starred", "assets/icons/icon-starred.svg", "Starred" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Avatar", "Name" },
                values: new object[] { 1, "assets/avatars/avatar-1.png", "James Alto" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Navigations");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
