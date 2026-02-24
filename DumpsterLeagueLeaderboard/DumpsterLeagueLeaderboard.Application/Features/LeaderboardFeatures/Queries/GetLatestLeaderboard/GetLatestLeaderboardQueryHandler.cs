using DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Queries.GetLatestLeaderboard;

public class GetLatestLeaderboardQueryHandler : IRequestHandler<GetLatestLeaderboardQuery, List<LatestLeaderboardDto>>
{
    private readonly ILeaderboardQueryRepository _leaderboardQueryRepository;
    private readonly IPlayerQueryRepository _playerQueryRepository;
    private readonly ILeagueEventQueryRepository _leagueEventQueryRepository;
    private readonly ISeasonQueryRepository _seasonQueryRepository;
    private readonly ITournamentQueryRepository _tournamentQueryRepository;

    public GetLatestLeaderboardQueryHandler(
        ILeaderboardQueryRepository leaderboardQueryRepository,
        IPlayerQueryRepository playerQueryRepository,
        ILeagueEventQueryRepository leagueEventQueryRepository,
        ISeasonQueryRepository seasonQueryRepository,
        ITournamentQueryRepository tournamentQueryRepository)
    {
        _leaderboardQueryRepository = leaderboardQueryRepository;
        _playerQueryRepository = playerQueryRepository;
        _leagueEventQueryRepository = leagueEventQueryRepository;
        _seasonQueryRepository = seasonQueryRepository;
        _tournamentQueryRepository = tournamentQueryRepository;
    }

    public async Task<List<LatestLeaderboardDto>> Handle(GetLatestLeaderboardQuery request, CancellationToken cancellationToken)
    {
        var results = new List<LatestLeaderboardDto>();
        var latestLeaderboards = await _leaderboardQueryRepository.GetCurrentLeaderboard(request.LeagueEventId, request.SeasonId, cancellationToken);
        foreach (var leaderboard in latestLeaderboards)
        {
            var player = await _playerQueryRepository.GetByIdAsync(leaderboard.PlayerId, true, cancellationToken);
            var leagueEvent = await _leagueEventQueryRepository.GetByIdAsync(leaderboard.LeagueEventId, true, cancellationToken);
            var season = await _seasonQueryRepository.GetByIdAsync(leaderboard.SeasonId, true, cancellationToken);
            var tournament = await _tournamentQueryRepository.GetByIdAsync(leaderboard.TournamentId, true, cancellationToken);

            var result = new LatestLeaderboardDto
            {
                Position = leaderboard.Placement,
                PlayerIGN = player!.CurrentIgn,
                LeagueEventName = leagueEvent!.EventName,
                SeasonName = season!.SeasonName,
                SeasonStart = season!.SeasonStartDate,
                SeasonEnd = season!.SeasonEndDate,
                LastTournamentName = tournament!.TournamentName,
                LastTournamentDate = tournament!.TournamentDate,
                IsDisqualified = leaderboard.IsDisqualified,
                PreviousPoints = leaderboard.PreviousPoints,
                PointsGained = leaderboard.PointsGained,
                CurrentPoints = leaderboard.CurrentPoints
            };
            results.Add(result);
        }
        results = results.OrderBy(r => r.Position).ToList();
        return results;

    }
}
