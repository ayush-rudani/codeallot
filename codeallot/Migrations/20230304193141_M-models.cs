using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codeallot.Migrations
{
    /// <inheritdoc />
    public partial class Mmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodexCount",
                table: "Codexes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodexCount",
                table: "Codexes",
                type: "int",
                nullable: true);
        }
    }
}
