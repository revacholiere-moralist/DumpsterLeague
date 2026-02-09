using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DumpsterLeagueLeaderboard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "playerplacementhistory_id",
                table: "player_placement_histories",
                newName: "player_placement_history_id");

            migrationBuilder.RenameColumn(
                name: "leagueevent_id",
                table: "league_events",
                newName: "league_event_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "player_placement_history_id",
                table: "player_placement_histories",
                newName: "playerplacementhistory_id");

            migrationBuilder.RenameColumn(
                name: "league_event_id",
                table: "league_events",
                newName: "leagueevent_id");
        }
    }
}
