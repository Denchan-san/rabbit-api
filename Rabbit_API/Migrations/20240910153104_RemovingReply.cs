using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rabbit_API.Migrations
{
    /// <inheritdoc />
    public partial class RemovingReply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.AddColumn<int>(
                name: "CommentaryToId",
                table: "Commentaries",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentaryToId",
                table: "Commentaries");

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildCommentaryId = table.Column<int>(type: "int", nullable: true),
                    ParentalCommentaryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Replies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_Commentaries_ChildCommentaryId",
                        column: x => x.ChildCommentaryId,
                        principalTable: "Commentaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_Commentaries_ParentalCommentaryId",
                        column: x => x.ParentalCommentaryId,
                        principalTable: "Commentaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ChildCommentaryId",
                table: "Replies",
                column: "ChildCommentaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ParentalCommentaryId",
                table: "Replies",
                column: "ParentalCommentaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                column: "UserId");
        }
    }
}
