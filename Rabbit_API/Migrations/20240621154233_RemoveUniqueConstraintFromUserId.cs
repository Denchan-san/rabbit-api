using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rabbit_API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueConstraintFromUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Удаление уникального индекса
            migrationBuilder.DropIndex(
                name: "IX_Commentaries_UserId",
                table: "Commentaries");

            // Создание неуникального индекса
            migrationBuilder.CreateIndex(
                name: "IX_Commentaries_UserId",
                table: "Commentaries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаление неуникального индекса
            migrationBuilder.DropIndex(
                name: "IX_Commentaries_UserId",
                table: "Commentaries");

            // Восстановление уникального индекса
            migrationBuilder.CreateIndex(
                name: "IX_Commentaries_UserId",
                table: "Commentaries",
                column: "UserId",
                unique: true);
        }
    }
}
