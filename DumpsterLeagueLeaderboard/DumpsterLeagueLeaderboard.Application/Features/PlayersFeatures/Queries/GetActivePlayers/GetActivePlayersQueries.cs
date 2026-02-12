using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Responses;
using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Queries.GetActivePlayers;

public record GetActivePlayersQuery() : IRequest<List<PlayerDto>>;