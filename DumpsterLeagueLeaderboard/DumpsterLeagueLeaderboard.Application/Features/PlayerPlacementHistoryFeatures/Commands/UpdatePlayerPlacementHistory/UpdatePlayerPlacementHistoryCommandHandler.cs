using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Features.PlayerPlacementHistoryFeatures.Responses;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayerPlacementHistoryFeatures.Command.UpdatePlayerPlacementHistory;
    
public class UpdatePlayerPlacementHistoryCommandHandler : IRequestHandler<UpdatePlayerPlacementHistoryCommand, PlayerPlacementHistoryDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlayerPlacementHistoryRepository _playerPlacementHistoryRepository;
    private readonly IPlayerPlacementHistoryQueryRepository _playerPlacementHistoryQueryRepository;
    private readonly ITournamentQueryRepository _tournamentQueryRepository;
    private readonly IPointQueryRepository _pointQueryRepository;

    public UpdatePlayerPlacementHistoryCommandHandler(
        IUnitOfWork unitOfWork,
        IPlayerPlacementHistoryRepository playerPlacementHistoryRepository,
        IPlayerPlacementHistoryQueryRepository playerPlacementHistoryQueryRepository,
        ITournamentQueryRepository tournamentQueryRepository,
        IPointQueryRepository pointQueryRepository
        )
    {
        _unitOfWork = unitOfWork;
        _playerPlacementHistoryRepository = playerPlacementHistoryRepository;
        _playerPlacementHistoryQueryRepository = playerPlacementHistoryQueryRepository;
        _tournamentQueryRepository = tournamentQueryRepository;
        _pointQueryRepository = pointQueryRepository;
    }

    public async Task<PlayerPlacementHistoryDto> Handle(UpdatePlayerPlacementHistoryCommand request, CancellationToken cancellationToken)
    {
        var existingPlayerPlacementHistory = await _playerPlacementHistoryQueryRepository.GetByIdAsync(request.Request.PlayerPlacementHistoryId, true, cancellationToken);
        var tournamentId = request.Request.TournamentId;
        var tournament = await _tournamentQueryRepository.GetByIdAsync(tournamentId);
        var seasonId = tournament.SeasonId!.Value;
        var pointsGained = await _pointQueryRepository.GetPointsByEventAndSeasonAsync(tournament.LeagueEventId!.Value, tournament.SeasonId!.Value, cancellationToken);

        if (existingPlayerPlacementHistory is null)
        {
            throw new Exception("Player Placement History does not exist.");
        }

        existingPlayerPlacementHistory.PlayerId = request.Request.PlayerId;
        existingPlayerPlacementHistory.Placement = request.Request.Placement;
        existingPlayerPlacementHistory.IsDisqualified = request.Request.IsDisqualified;
        existingPlayerPlacementHistory.TournamentId = request.Request.TournamentId;
        existingPlayerPlacementHistory.IsCurrent = request.Request.IsCurrent;
        existingPlayerPlacementHistory.UpdatedAt = DateTime.UtcNow;
        

        int playerLastPoint = 0;

        var playerPlacements = await _playerPlacementHistoryQueryRepository.GetByEventAndSeason(tournament.LeagueEventId!.Value, tournament.SeasonId!.Value, request.Request.PlayerId);
        if (playerPlacements.Count > 0)
        {
            playerLastPoint = 0;
            playerPlacements = playerPlacements.Where(p => p.Id != existingPlayerPlacementHistory.Id).OrderByDescending(p => p.Tournament.TournamentDate).ToList();
            foreach (var playerPlacement in playerPlacements)
            {
                playerPlacement.IsCurrent = false;
                await _playerPlacementHistoryRepository.Update(playerPlacement);
            }
            if (playerPlacements.Count > 0)
            {
                var lastPlayerPlacement = playerPlacements.First();
                playerLastPoint = lastPlayerPlacement.CurrentPoints;
            }
        }
        
        var pointGained = pointsGained.First(x => x.Position == request.Request.Placement).PointGained;
        var currentPoint = playerLastPoint + pointGained;

        existingPlayerPlacementHistory.PreviousPoints = playerLastPoint;
        existingPlayerPlacementHistory.PointsGained = pointGained;
        existingPlayerPlacementHistory.CurrentPoints = currentPoint;

        await _playerPlacementHistoryRepository.Update(existingPlayerPlacementHistory);
        await _unitOfWork.Save(cancellationToken);
        
        return new PlayerPlacementHistoryDto
        {
            PlayerId = existingPlayerPlacementHistory.PlayerId,
            TournamentId = existingPlayerPlacementHistory.TournamentId,
            Placement = existingPlayerPlacementHistory.Placement,
            CurrentPoints = currentPoint,
            PointsGained = pointGained,
            IsCurrent = existingPlayerPlacementHistory.IsCurrent
        };

    }
}
