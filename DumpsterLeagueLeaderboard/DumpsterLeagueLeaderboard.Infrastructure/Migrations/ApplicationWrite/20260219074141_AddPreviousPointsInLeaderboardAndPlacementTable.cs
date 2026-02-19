using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DumpsterLeagueLeaderboard.Infrastructure.Migrations.ApplicationWrite
{
    /// <inheritdoc />
    public partial class AddPreviousPointsInLeaderboardAndPlacementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "previous_points",
                table: "player_placement_histories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "previous_points",
                table: "leaderboards",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "previous_points",
                table: "player_placement_histories");

            migrationBuilder.DropColumn(
                name: "previous_points",
                table: "leaderboards");
        }
    }
}
