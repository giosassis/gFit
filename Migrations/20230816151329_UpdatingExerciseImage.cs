using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gFit.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingExerciseImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "ExerciseImage");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExerciseImage",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExerciseImage");

            migrationBuilder.AddColumn<Guid>(
                name: "ExerciseId",
                table: "ExerciseImage",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
