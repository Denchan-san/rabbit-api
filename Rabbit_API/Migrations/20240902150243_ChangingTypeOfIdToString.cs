using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rabbit_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTypeOfIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LocalUsers",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LocalUsers",
                newName: "ID");
        }
    }
}
