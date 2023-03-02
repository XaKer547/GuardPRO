using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardPRO.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Invites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invites_UserId",
                table: "Invites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Users_UserId",
                table: "Invites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Users_UserId",
                table: "Invites");

            migrationBuilder.DropIndex(
                name: "IX_Invites_UserId",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Invites");
        }
    }
}
