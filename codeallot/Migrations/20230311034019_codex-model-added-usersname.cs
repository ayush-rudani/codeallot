using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codeallot.Migrations
{
    /// <inheritdoc />
    public partial class codexmodeladdedusersname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codexes_Users_CreatedById",
                table: "Codexes");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Codexes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Codexes_CreatedById",
                table: "Codexes",
                newName: "IX_Codexes_UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Codexes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Codexes_Users_UserId",
                table: "Codexes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codexes_Users_UserId",
                table: "Codexes");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Codexes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Codexes",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Codexes_UserId",
                table: "Codexes",
                newName: "IX_Codexes_CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Codexes_Users_CreatedById",
                table: "Codexes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
