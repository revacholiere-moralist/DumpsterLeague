using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Queries.GetTournamentsByEventAndSeason;

public record GetTournamentsByEventAndSeasonQuery(Guid LeagueEventId, Guid SeasonId) : IRequest<List<TournamentDto>>;