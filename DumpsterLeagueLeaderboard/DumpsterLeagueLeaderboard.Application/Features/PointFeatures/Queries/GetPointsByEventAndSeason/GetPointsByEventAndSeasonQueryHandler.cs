using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
namespace DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Queries.GetPointsByEventAndSeason;
    
public class GetPointsByEventAndSeasonQueryHandler : IRequestHandler<GetPointsByEventAndSeasonQuery, List<PointDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IPointQueryRepository _pointQueryRepository;
    private readonly ILeagueEventQueryRepository _leagueEventQueryRepository;
    private readonly ISeasonQueryRepository _seasonQueryRepository;

    public GetPointsByEventAndSeasonQueryHandler(
        IUnitOfWork unitOfWork,
        IPointQueryRepository pointQueryRepository,
        ILeagueEventQueryRepository leagueEventQueryRepository,
        ISeasonQueryRepository seasonQueryRepository)
    {
        _unitOfWork = unitOfWork;
        _pointQueryRepository = pointQueryRepository;
        _leagueEventQueryRepository = leagueEventQueryRepository;
        _seasonQueryRepository = seasonQueryRepository;
    }

    public async Task<List<PointDto>> Handle(GetPointsByEventAndSeasonQuery request, CancellationToken cancellationToken)
    {
        var leagueEvent = await _leagueEventQueryRepository.GetByIdAsync(request.LeagueEventId, true, cancellationToken);
        if (leagueEvent is null)
        {
            throw new ArgumentException("League event not found.");
        }
        var season = await _seasonQueryRepository.GetByIdAsync(request.SeasonId, true, cancellationToken);
        if (season is null)
        {
            throw new ArgumentException("Season not found.");
        }
        
        var points = await _pointQueryRepository.GetPointsByEventAndSeasonAsync(request.LeagueEventId, request.SeasonId, cancellationToken);

        return points.Select(p => new PointDto
        {
            Id = p.Id,
            LeagueEventId = p.LeagueEventId,
            SeasonId = p.SeasonId,
            Position = p.Position,
            PointGained = p.PointGained,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt,
            IsActive = p.IsActive
        }).ToList();

        //TODO: More specific exception handli

    }
}
