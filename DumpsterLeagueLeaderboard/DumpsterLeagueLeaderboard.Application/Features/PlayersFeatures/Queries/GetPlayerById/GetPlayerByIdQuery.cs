using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Responses;
using MediatR;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Queries.GetPlayerById;

public record GetPlayerByIdQuery(Guid Id) : IRequest<PlayerDto>;