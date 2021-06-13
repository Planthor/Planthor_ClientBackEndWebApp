using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanthorWebApiServer.Migrations
{
    public partial class ChangeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberGoals");

            migrationBuilder.CreateTable(
                name: "GoalMember",
                columns: table => new
                {
                    GoalsGoalId = table.Column<Guid>(type: "uuid", nullable: false),
                    MembersMemberId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalMember", x => new { x.GoalsGoalId, x.MembersMemberId });
                    table.ForeignKey(
                        name: "FK_GoalMember_Goals_GoalsGoalId",
                        column: x => x.GoalsGoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalMember_Members_MembersMemberId",
                        column: x => x.MembersMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoalMember_MembersMemberId",
                table: "GoalMember",
                column: "MembersMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalMember");

            migrationBuilder.CreateTable(
                name: "MemberGoals",
                columns: table => new
                {
                    MemberGoalsId = table.Column<Guid>(type: "uuid", nullable: false),
                    GoalId = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberGoals", x => x.MemberGoalsId);
                    table.ForeignKey(
                        name: "FK_MemberGoals_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberGoals_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberGoals_GoalId",
                table: "MemberGoals",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberGoals_MemberId",
                table: "MemberGoals",
                column: "MemberId");
        }
    }
}
