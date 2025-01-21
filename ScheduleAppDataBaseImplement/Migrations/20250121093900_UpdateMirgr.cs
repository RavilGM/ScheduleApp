using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleAppDataBaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMirgr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonNumbers",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonNumbers",
                table: "Schedules");
        }
    }
}
