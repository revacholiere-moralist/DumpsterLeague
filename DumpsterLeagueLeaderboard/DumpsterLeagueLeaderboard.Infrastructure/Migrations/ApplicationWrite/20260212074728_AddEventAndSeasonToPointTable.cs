using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DumpsterLeagueLeaderboard.Infrastructure.Migrations.ApplicationWrite
{
    /// <inheritdoc />
    public partial class AddEventAndSeasonToPointTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "league_events",
                columns: table => new
                {
                    league_event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_name = table.Column<string>(type: "text", nullable: false),
                    is_ongoing = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_league_events", x => x.league_event_id);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    player_id = table.Column<Guid>(type: "uuid", nullable: false),
                    current_discord_id = table.Column<string>(type: "text", nullable: false),
                    current_discord_name = table.Column<string>(type: "text", nullable: false),
                    current_ign = table.Column<string>(type: "text", nullable: false),
                    current_points = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.player_id);
                });

            migrationBuilder.CreateTable(
                name: "seasons",
                columns: table => new
                {
                    season_id = table.Column<Guid>(type: "uuid", nullable: false),
                    league_event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    season_name = table.Column<string>(type: "text", nullable: false),
                    season_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    season_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_current = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seasons", x => x.season_id);
                    table.ForeignKey(
                        name: "FK_seasons_league_events_league_event_id",
                        column: x => x.league_event_id,
                        principalTable: "league_events",
                        principalColumn: "league_event_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "points",
                columns: table => new
                {
                    point_id = table.Column<Guid>(type: "uuid", nullable: false),
                    league_event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    season_id = table.Column<Guid>(type: "uuid", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false),
                    point_gained = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_points", x => x.point_id);
                    table.ForeignKey(
                        name: "FK_points_league_events_league_event_id",
                        column: x => x.league_event_id,
                        principalTable: "league_events",
                        principalColumn: "league_event_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_points_seasons_season_id",
                        column: x => x.season_id,
                        principalTable: "seasons",
                        principalColumn: "season_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tournaments",
                columns: table => new
                {
                    tournament_id = table.Column<Guid>(type: "uuid", nullable: false),
                    league_event_id = table.Column<Guid>(type: "uuid", nullable: true),
                    season_id = table.Column<Guid>(type: "uuid", nullable: true),
                    tournament_name = table.Column<string>(type: "text", nullable: false),
                    tournament_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    start_gg_link = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tournaments", x => x.tournament_id);
                    table.ForeignKey(
                        name: "FK_tournaments_league_events_league_event_id",
                        column: x => x.league_event_id,
                        principalTable: "league_events",
                        principalColumn: "league_event_id");
                    table.ForeignKey(
                        name: "FK_tournaments_seasons_season_id",
                        column: x => x.season_id,
                        principalTable: "seasons",
                        principalColumn: "season_id");
                });

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

            migrationBuilder.CreateTable(
                name: "player_placement_histories",
                columns: table => new
                {
                    player_placement_history_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tournament_id = table.Column<Guid>(type: "uuid", nullable: false),
                    placement = table.Column<int>(type: "integer", nullable: false),
                    current_points = table.Column<int>(type: "integer", nullable: false),
                    points_gained = table.Column<int>(type: "integer", nullable: false),
                    is_current = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_placement_histories", x => x.player_placement_history_id);
                    table.ForeignKey(
                        name: "FK_player_placement_histories_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_player_placement_histories_tournaments_tournament_id",
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

            migrationBuilder.CreateIndex(
                name: "IX_player_placement_histories_player_id",
                table: "player_placement_histories",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_placement_histories_tournament_id",
                table: "player_placement_histories",
                column: "tournament_id");

            migrationBuilder.CreateIndex(
                name: "IX_points_league_event_id",
                table: "points",
                column: "league_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_points_season_id",
                table: "points",
                column: "season_id");

            migrationBuilder.CreateIndex(
                name: "IX_seasons_league_event_id",
                table: "seasons",
                column: "league_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_tournaments_league_event_id",
                table: "tournaments",
                column: "league_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_tournaments_season_id",
                table: "tournaments",
                column: "season_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaderboards");

            migrationBuilder.DropTable(
                name: "player_placement_histories");

            migrationBuilder.DropTable(
                name: "points");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "tournaments");

            migrationBuilder.DropTable(
                name: "seasons");

            migrationBuilder.DropTable(
                name: "league_events");
        }
    }
}
