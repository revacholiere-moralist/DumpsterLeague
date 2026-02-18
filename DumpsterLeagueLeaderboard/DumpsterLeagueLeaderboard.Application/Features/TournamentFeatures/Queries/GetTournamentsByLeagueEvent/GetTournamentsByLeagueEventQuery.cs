using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Queries.GetTournamentsByLeagueEvent;

public record GetTournamentsByLeagueEventQuery(Guid LeagueEventId) : IRequest<List<TournamentDto>>;