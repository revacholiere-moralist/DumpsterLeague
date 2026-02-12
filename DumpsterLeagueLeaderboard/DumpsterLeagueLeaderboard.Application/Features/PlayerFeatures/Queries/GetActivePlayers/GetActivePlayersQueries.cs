using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Queries.GetActivePlayers;

public record GetActivePlayersQuery() : IRequest<List<PlayerDto>>;