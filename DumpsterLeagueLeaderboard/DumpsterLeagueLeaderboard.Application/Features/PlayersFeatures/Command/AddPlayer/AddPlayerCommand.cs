using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Responses;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Command.AddPlayer;

public record AddPlayerCommand(AddPlayerRequest Request) : IRequest<PlayerDto>;
