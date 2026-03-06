using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dropbox_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ModifiedDate = table.Column<string>(type: "text", nullable: false),
                    InsideFiles = table.Column<int>(type: "integer", nullable: false),
                    SharedUsersCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecentFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false),
                    ModifiedDate = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    SharedUsersCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Used = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    Percentage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "InsideFiles", "ModifiedDate", "Name", "SharedUsersCount" },
                values: new object[,]
                {
                    { 1, 3985, "Sep 25, 2022, 13:25 PM", "Documents", 86 },
                    { 2, 499, "Sep 25, 2022, 13:25 PM", "Music", 85 },
                    { 3, 256, "Sep 25, 2022, 13:25 PM", "ProjectK", 0 },
                    { 4, 1225, "Sep 25, 2022, 13:25 PM", "Rico Media", 52 },
                    { 5, 2265, "Sep 25, 2022, 13:25 PM", "New Dev", 22 },
                    { 6, 597, "Sep 25, 2022, 13:25 PM", "Files 2022", 12 }
                });

            migrationBuilder.InsertData(
                table: "RecentFiles",
                columns: new[] { "Id", "Icon", "ModifiedDate", "Name", "SharedUsersCount", "Size", "Type" },
                values: new object[,]
                {
                    { 1, "assets/icons/icon-file-image.svg", "Dec 13, 2022", "Website Design.png", 12, "2.8 MB", "image" },
                    { 2, "assets/icons/icon-folder.svg", "Dec 12, 2022", "UX-UI.zip", 5, "242 MB", "archive" },
                    { 3, "assets/icons/icon-video.svg", "Dec 12, 2022", "Office.mp4", 0, "1.8 GB", "video" }
                });

            migrationBuilder.InsertData(
                table: "Storage",
                columns: new[] { "Id", "Percentage", "Total", "Unit", "Used" },
                values: new object[] { 1, 75, 800, "GB", 600 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "RecentFiles");

            migrationBuilder.DropTable(
                name: "Storage");
        }
    }
}
