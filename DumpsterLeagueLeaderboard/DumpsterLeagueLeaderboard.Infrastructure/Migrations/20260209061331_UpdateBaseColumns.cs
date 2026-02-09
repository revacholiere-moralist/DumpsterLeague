using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DumpsterLeagueLeaderboard.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tournaments_league_events_league_event_id",
                table: "tournaments");

            migrationBuilder.AlterColumn<Guid>(
                name: "league_event_id",
                table: "tournaments",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_tournaments_league_events_league_event_id",
                table: "tournaments",
                column: "league_event_id",
                principalTable: "league_events",
                principalColumn: "league_event_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tournaments_league_events_league_event_id",
                table: "tournaments");

            migrationBuilder.AlterColumn<Guid>(
                name: "league_event_id",
                table: "tournaments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tournaments_league_events_league_event_id",
                table: "tournaments",
                column: "league_event_id",
                principalTable: "league_events",
                principalColumn: "league_event_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
