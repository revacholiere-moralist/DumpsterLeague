using DumpsterLeagueLeaderboard.Application.Features.PlayerPlacementHistoryFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Domain.Entities;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.PlayerPlacementHistoryFeatures.Commands.AddPlayerPlacementHistory;

public class AddPlayerPlacementHistoryCommandHandler : IRequestHandler<AddPlayerPlacementHistoryCommand, List<PlayerPlacementHistoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlayerPlacementHistoryRepository _playerPlacementHistoryRepository;
    private readonly IPlayerPlacementHistoryQueryRepository _playerPlacementQueryRepository;
    private readonly ITournamentQueryRepository _tournamentQueryRepository;
    private readonly IPointQueryRepository _pointQueryRepository;

    public AddPlayerPlacementHistoryCommandHandler(
        IUnitOfWork unitOfWork,
        IPlayerPlacementHistoryRepository playerPlacementHistoryRepository,
        IPlayerPlacementHistoryQueryRepository playerPlacementHistoryQueryRepository,
        ITournamentQueryRepository tournamentQueryRepository,
        IPointQueryRepository pointQueryRepository)
    {
        _unitOfWork = unitOfWork;
        _playerPlacementHistoryRepository = playerPlacementHistoryRepository;
        _playerPlacementQueryRepository = playerPlacementHistoryQueryRepository;
        _tournamentQueryRepository = tournamentQueryRepository;
        _pointQueryRepository = pointQueryRepository;
    }

    public async Task<List<PlayerPlacementHistoryDto>> Handle(AddPlayerPlacementHistoryCommand request, CancellationToken cancellationToken)
    {
        //TODO: Add null validations
        var tournamentId = request.Request.TournamentId;
        var tournament = await _tournamentQueryRepository.GetByIdAsync(tournamentId);
        var seasonId = tournament.SeasonId!.Value;
        var pointsGained = await _pointQueryRepository.GetPointsByEventAndSeasonAsync(tournament.LeagueEventId!.Value, tournament.SeasonId!.Value, cancellationToken);
        var addedPlayerPlacementHistories = new List<PlayerPlacementHistory>();
        
        foreach (var playerPlacementRequest in request.Request.Players)
        {

            var playerPlacementHistory = new PlayerPlacementHistory
            {
                PlayerId = playerPlacementRequest.PlayerId,
                Placement = playerPlacementRequest.Placement,
                TournamentId = tournamentId,
                IsCurrent = playerPlacementRequest.IsCurrent,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true
            };

            int playerLastPoint = 0;

            var playerPlacements = await _playerPlacementQueryRepository.GetByEventAndSeason(tournament.LeagueEventId!.Value, tournament.SeasonId!.Value, playerPlacementRequest.PlayerId);
            if (playerPlacements.Count > 0)
            {
                playerPlacements = playerPlacements.OrderByDescending(p => p.Tournament.TournamentDate).ToList();
                foreach (var playerPlacement in playerPlacements)
                {
                    playerPlacement.IsCurrent = false;
                    await _playerPlacementHistoryRepository.Update(playerPlacement);
                }
                var lastPlayerPlacement = playerPlacements.First();
                playerLastPoint = lastPlayerPlacement.CurrentPoints;
            }

            var pointGained = pointsGained.First(x => x.Position == playerPlacementRequest.Placement).PointGained;
            var currentPoint = playerLastPoint + pointGained;

            playerPlacementHistory.PointsGained = pointGained;
            playerPlacementHistory.CurrentPoints = currentPoint;

            var addedPlayerPlacementHistory = await _playerPlacementHistoryRepository.AddAsync(playerPlacementHistory, cancellationToken);
            addedPlayerPlacementHistories.Add(addedPlayerPlacementHistory);

        }
        try
        {
            await _unitOfWork.Save(cancellationToken);
            return addedPlayerPlacementHistories.Select(p => new PlayerPlacementHistoryDto
            {
                Id = p.Id,
                PlayerId = p.PlayerId,
                TournamentId = p.TournamentId,
                Placement = p.Placement,
                CurrentPoints = p.CurrentPoints,
                PointsGained = p.PointsGained,
                IsCurrent = p.IsCurrent,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                IsActive = p.IsActive
            }).ToList();
        }

        //TODO: More specific exception handling
        catch (Exception ex)
        {
            // Handle exception (e.g., log it)
            throw new ApplicationException("An error occurred while saving the league event.", ex);
        }
    }
}
