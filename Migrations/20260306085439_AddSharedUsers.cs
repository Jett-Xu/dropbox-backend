using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dropbox_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSharedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SharedUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    FolderId = table.Column<int>(type: "integer", nullable: true),
                    RecentFileId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedUsers_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SharedUsers_RecentFiles_RecentFileId",
                        column: x => x.RecentFileId,
                        principalTable: "RecentFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "SharedUsers",
                columns: new[] { "Id", "Avatar", "FolderId", "Name", "RecentFileId" },
                values: new object[,]
                {
                    { 1, "assets/avatars/avatar-1.png", 1, "User 1", null },
                    { 2, "assets/avatars/avatar-2.png", 1, "User 2", null },
                    { 3, "assets/avatars/avatar-3.png", 1, "User 3", null },
                    { 4, "assets/avatars/avatar-4.png", 1, "User 4", null },
                    { 5, "assets/avatars/avatar-1.png", 1, "User 5", null },
                    { 6, "assets/avatars/avatar-2.png", 1, "User 6", null },
                    { 7, "assets/avatars/avatar-1.png", 2, "User 1", null },
                    { 8, "assets/avatars/avatar-2.png", 2, "User 2", null },
                    { 9, "assets/avatars/avatar-3.png", 2, "User 3", null },
                    { 10, "assets/avatars/avatar-4.png", 2, "User 4", null },
                    { 11, "assets/avatars/avatar-1.png", 2, "User 5", null },
                    { 12, "assets/avatars/avatar-2.png", 2, "User 6", null },
                    { 13, "assets/avatars/avatar-1.png", 3, "User 1", null },
                    { 14, "assets/avatars/avatar-2.png", 3, "User 2", null },
                    { 15, "assets/avatars/avatar-3.png", 3, "User 3", null },
                    { 16, "assets/avatars/avatar-1.png", 4, "User 1", null },
                    { 17, "assets/avatars/avatar-2.png", 4, "User 2", null },
                    { 18, "assets/avatars/avatar-3.png", 4, "User 3", null },
                    { 19, "assets/avatars/avatar-4.png", 4, "User 4", null },
                    { 20, "assets/avatars/avatar-1.png", 5, "User 1", null },
                    { 21, "assets/avatars/avatar-2.png", 5, "User 2", null },
                    { 22, "assets/avatars/avatar-3.png", 5, "User 3", null },
                    { 23, "assets/avatars/avatar-4.png", 5, "User 4", null },
                    { 24, "assets/avatars/avatar-1.png", 6, "User 1", null },
                    { 25, "assets/avatars/avatar-2.png", 6, "User 2", null },
                    { 26, "assets/avatars/avatar-3.png", 6, "User 3", null },
                    { 27, "assets/avatars/avatar-1.png", null, "User 1", 1 },
                    { 28, "assets/avatars/avatar-2.png", null, "User 2", 1 },
                    { 29, "assets/avatars/avatar-3.png", null, "User 3", 1 },
                    { 30, "assets/avatars/avatar-4.png", null, "User 4", 1 },
                    { 31, "assets/avatars/avatar-1.png", null, "User 5", 1 },
                    { 32, "assets/avatars/avatar-2.png", null, "User 6", 1 },
                    { 33, "assets/avatars/avatar-1.png", null, "User 1", 2 },
                    { 34, "assets/avatars/avatar-2.png", null, "User 2", 2 },
                    { 35, "assets/avatars/avatar-3.png", null, "User 3", 2 },
                    { 36, "assets/avatars/avatar-4.png", null, "User 4", 2 },
                    { 37, "assets/avatars/avatar-1.png", null, "User 5", 2 },
                    { 38, "assets/avatars/avatar-1.png", null, "User 1", 3 },
                    { 39, "assets/avatars/avatar-2.png", null, "User 2", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SharedUsers_FolderId",
                table: "SharedUsers",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedUsers_RecentFileId",
                table: "SharedUsers",
                column: "RecentFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SharedUsers");
        }
    }
}
