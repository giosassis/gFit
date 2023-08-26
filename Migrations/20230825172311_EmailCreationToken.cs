using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gFit.Migrations
{
    /// <inheritdoc />
    public partial class EmailCreationToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmationToken",
                table: "Personal",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "Personal",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmationToken",
                table: "Personal");

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "Personal");
        }
    }
}
