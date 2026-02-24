using DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Responses;
using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Queries.GetLatestLeaderboard;

public record GetLatestLeaderboardQuery(Guid LeagueEventId, Guid SeasonId) : IRequest<List<LatestLeaderboardDto>>;