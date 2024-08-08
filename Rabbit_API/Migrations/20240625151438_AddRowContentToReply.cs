using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rabbit_API.Migrations
{
    /// <inheritdoc />
    public partial class AddRowContentToReply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Replies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Replies");
        }
    }
}
