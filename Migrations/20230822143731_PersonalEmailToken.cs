using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gFit.Migrations
{
    /// <inheritdoc />
    public partial class PersonalEmailToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmationToken",
                table: "Personal",
                type: "text",
                nullable: true);

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
