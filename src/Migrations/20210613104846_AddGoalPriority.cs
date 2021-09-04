using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanthorWebApiServer.Migrations
{
    public partial class AddGoalPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalPriority",
                table: "Goals",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalPriority",
                table: "Goals");
        }
    }
}
