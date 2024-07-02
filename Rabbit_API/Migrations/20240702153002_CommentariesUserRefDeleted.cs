using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rabbit_API.Migrations
{
    /// <inheritdoc />
    public partial class CommentariesUserRefDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaries_LocalUsers_UserId",
                table: "Commentaries");

            migrationBuilder.DropIndex(
                name: "IX_Commentaries_UserId",
                table: "Commentaries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Commentaries_UserId",
                table: "Commentaries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaries_LocalUsers_UserId",
                table: "Commentaries",
                column: "UserId",
                principalTable: "LocalUsers",
                principalColumn: "ID");
        }
    }
}
