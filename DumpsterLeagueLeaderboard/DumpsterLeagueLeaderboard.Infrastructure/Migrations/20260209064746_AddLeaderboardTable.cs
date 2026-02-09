using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DumpsterLeagueLeaderboard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaderboardTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leaderboards",
                columns: table => new
                {
                    leaderboard_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tournament_id = table.Column<Guid>(type: "uuid", nullable: false),
                    league_event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    season_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_id = table.Column<Guid>(type: "uuid", nullable: false),
                    current_points = table.Column<int>(type: "integer", nullable: false),
                    points_gained = table.Column<int>(type: "integer", nullable: false),
                    placement = table.Column<int>(type: "integer", nullable: false),
                    leaderboard_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_disqualified = table.Column<bool>(type: "boolean", nullable: false),
                    is_current = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaderboards", x => x.leaderboard_id);
                    table.ForeignKey(
                        name: "FK_leaderboards_league_events_league_event_id",
                        column: x => x.league_event_id,
                        principalTable: "league_events",
                        principalColumn: "league_event_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaderboards_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaderboards_seasons_season_id",
                        column: x => x.season_id,
                        principalTable: "seasons",
                        principalColumn: "season_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaderboards_tournaments_tournament_id",
                        column: x => x.tournament_id,
                        principalTable: "tournaments",
                        principalColumn: "tournament_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_leaderboards_league_event_id",
                table: "leaderboards",
                column: "league_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_leaderboards_player_id",
                table: "leaderboards",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_leaderboards_season_id",
                table: "leaderboards",
                column: "season_id");

            migrationBuilder.CreateIndex(
                name: "IX_leaderboards_tournament_id",
                table: "leaderboards",
                column: "tournament_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaderboards");
        }
    }
}
