using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DumpsterLeagueLeaderboard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLeagueTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "league_event_id",
                table: "seasons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "league_events",
                columns: table => new
                {
                    leagueevent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_name = table.Column<string>(type: "text", nullable: false),
                    is_ongoing = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_league_events", x => x.leagueevent_id);
                });

            migrationBuilder.CreateTable(
                name: "tournaments",
                columns: table => new
                {
                    tournament_id = table.Column<Guid>(type: "uuid", nullable: false),
                    league_event_id = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalColumn: "leagueevent_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tournaments_seasons_season_id",
                        column: x => x.season_id,
                        principalTable: "seasons",
                        principalColumn: "season_id");
                });

            migrationBuilder.CreateTable(
                name: "player_placement_histories",
                columns: table => new
                {
                    playerplacementhistory_id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_player_placement_histories", x => x.playerplacementhistory_id);
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
                name: "IX_seasons_league_event_id",
                table: "seasons",
                column: "league_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_placement_histories_player_id",
                table: "player_placement_histories",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_placement_histories_tournament_id",
                table: "player_placement_histories",
                column: "tournament_id");

            migrationBuilder.CreateIndex(
                name: "IX_tournaments_league_event_id",
                table: "tournaments",
                column: "league_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_tournaments_season_id",
                table: "tournaments",
                column: "season_id");

            migrationBuilder.AddForeignKey(
                name: "FK_seasons_league_events_league_event_id",
                table: "seasons",
                column: "league_event_id",
                principalTable: "league_events",
                principalColumn: "leagueevent_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seasons_league_events_league_event_id",
                table: "seasons");

            migrationBuilder.DropTable(
                name: "player_placement_histories");

            migrationBuilder.DropTable(
                name: "tournaments");

            migrationBuilder.DropTable(
                name: "league_events");

            migrationBuilder.DropIndex(
                name: "IX_seasons_league_event_id",
                table: "seasons");

            migrationBuilder.DropColumn(
                name: "league_event_id",
                table: "seasons");
        }
    }
}
