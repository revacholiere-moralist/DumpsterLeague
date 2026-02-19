using DumpsterLeagueLeaderboard.Application.Features.GenerateLeaderboardFeatures.Commands.GenerateLeaderboard;
using DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Commands.GenerateLeaderboard;
public class GenerateLeaderboardCommandHandler : IRequestHandler<GenerateLeaderboardCommand, List<LeaderboardDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILeaderboardRepository _leaderboardRepository;
    private readonly ILeaderboardQueryRepository _leaderboardQueryRepository;
    private readonly IPlayerPlacementHistoryQueryRepository _playerPlacementHistoryQueryRepository;

    public GenerateLeaderboardCommandHandler(
        IUnitOfWork unitOfWork,
        ILeaderboardRepository leaderboardRepository,
        ILeaderboardQueryRepository leaderboardQueryRepository,
        IPlayerPlacementHistoryQueryRepository playerPlacementHistoryQueryRepository)
    {
        _unitOfWork = unitOfWork;
        _leaderboardRepository = leaderboardRepository;
        _leaderboardQueryRepository = leaderboardQueryRepository;
        _playerPlacementHistoryQueryRepository = playerPlacementHistoryQueryRepository;
    }

    public async Task<List<LeaderboardDto>> Handle(GenerateLeaderboardCommand request, CancellationToken cancellationToken)
    {
        var results = new List<LeaderboardDto>();

        var playerPlacements = await _playerPlacementHistoryQueryRepository.GetCurrentByEventAndSeason(request.Request.LeagueEventId, request.Request.SeasonId, cancellationToken);
        playerPlacements = playerPlacements
                            .OrderByDescending(p => p.CurrentPoints)
                            .ThenBy(p => p.Tournament.TournamentDate)
                            .ThenBy(p => p.Placement).ToList();
        
        var existingLeaderboards = await _leaderboardQueryRepository.GetCurrentLeaderboard(request.Request.LeagueEventId, request.Request.SeasonId, cancellationToken);
        if (existingLeaderboards.Count > 0)
        {
            foreach (var existingLeaderboard in existingLeaderboards)
            {
                existingLeaderboard.IsCurrent = false;
                await _leaderboardRepository.Update(existingLeaderboard);
            }
        }

        var position = 1;
        PlayerPlacementHistory? prevPlayerPlacement = null;
        foreach (var playerPlacement in playerPlacements)
        {
            var addedLeaderboard = new Leaderboard
            {
                PlayerId = playerPlacement.PlayerId,
                TournamentId = playerPlacement.TournamentId,
                LeagueEventId = playerPlacement.Tournament.LeagueEventId!.Value,
                SeasonId = playerPlacement.Tournament.SeasonId!.Value,
                IsDisqualified = playerPlacement.IsDisqualified,
                PreviousPoints = playerPlacement.PreviousPoints,
                PointsGained = playerPlacement.PointsGained,
                CurrentPoints = playerPlacement.CurrentPoints,
                LeaderboardDate = playerPlacement.Tournament.TournamentDate,
                IsCurrent = true,
                IsActive = true
            };
            
            if (prevPlayerPlacement is not null)
            {
                if (playerPlacement.CurrentPoints != prevPlayerPlacement.CurrentPoints 
                        || playerPlacement.Tournament.TournamentDate != prevPlayerPlacement.Tournament.TournamentDate
                        || playerPlacement.Placement != prevPlayerPlacement.Placement)
                {
                    position++;
                }
            }
            addedLeaderboard.Placement = position;

            prevPlayerPlacement = playerPlacement;
            await _leaderboardRepository.AddAsync(addedLeaderboard);
            var result = new LeaderboardDto
            {
                Id = addedLeaderboard.Id,
                PlayerId = addedLeaderboard.PlayerId,
                TournamentId = addedLeaderboard.TournamentId,
                LeagueEventId = request.Request.LeagueEventId,
                SeasonId = request.Request.SeasonId,
                IsDisqualified = addedLeaderboard.IsDisqualified,
                PreviousPoints = addedLeaderboard.PreviousPoints,
                PointsGained = addedLeaderboard.PointsGained,
                CurrentPoints = addedLeaderboard.CurrentPoints,
                Position = position,
                IsCurrent = true,
                IsActive = true
            };
            results.Add(result);
        }
        await _unitOfWork.Save(cancellationToken);
        return results;

    }
}
