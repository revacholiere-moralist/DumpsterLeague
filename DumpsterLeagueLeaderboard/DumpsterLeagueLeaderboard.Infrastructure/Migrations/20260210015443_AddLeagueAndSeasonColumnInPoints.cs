using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DumpsterLeagueLeaderboard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLeagueAndSeasonColumnInPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "league_event_id",
                table: "points",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "season_id",
                table: "points",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_points_league_event_id",
                table: "points",
                column: "league_event_id");

            migrationBuilder.CreateIndex(
                name: "IX_points_season_id",
                table: "points",
                column: "season_id");

            migrationBuilder.AddForeignKey(
                name: "FK_points_league_events_league_event_id",
                table: "points",
                column: "league_event_id",
                principalTable: "league_events",
                principalColumn: "league_event_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_points_seasons_season_id",
                table: "points",
                column: "season_id",
                principalTable: "seasons",
                principalColumn: "season_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_points_league_events_league_event_id",
                table: "points");

            migrationBuilder.DropForeignKey(
                name: "FK_points_seasons_season_id",
                table: "points");

            migrationBuilder.DropIndex(
                name: "IX_points_league_event_id",
                table: "points");

            migrationBuilder.DropIndex(
                name: "IX_points_season_id",
                table: "points");

            migrationBuilder.DropColumn(
                name: "league_event_id",
                table: "points");

            migrationBuilder.DropColumn(
                name: "season_id",
                table: "points");
        }
    }
}
