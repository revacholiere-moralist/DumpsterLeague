using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Responses;
namespace DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Commands.AddPoint;
    
public class AddPointCommandHandler : IRequestHandler<AddPointCommand, PointDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPointRepository _pointRepository;

    public AddPointCommandHandler(
        IUnitOfWork unitOfWork,
        IPointRepository pointRepository)
    {
        _unitOfWork = unitOfWork;
        _pointRepository = pointRepository;
    }

    public async Task<PointDto> Handle(AddPointCommand request, CancellationToken cancellationToken)
    {
        var point = new Point   
        {
            LeagueEventId = request.Request.LeagueEventId,
            SeasonId = request.Request.SeasonId,
            Position = request.Request.Position,
            PointGained = request.Request.PointGained,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };

        var addedPoint = await _pointRepository.AddAsync(point, cancellationToken);

        try
        {
            await _unitOfWork.Save(cancellationToken);
            return new PointDto
            {
                Id = addedPoint.Id,
                LeagueEventId = addedPoint.LeagueEventId,
                SeasonId = addedPoint.SeasonId,
                Position = addedPoint.Position,
                PointGained = addedPoint.PointGained,
                CreatedAt = addedPoint.CreatedAt,
                UpdatedAt = addedPoint.UpdatedAt,
                IsActive = addedPoint.IsActive
            };
        }

        //TODO: More specific exception handling
        catch (Exception ex)
        {
            // Handle exception (e.g., log it)
            throw new ApplicationException("An error occurred while saving the league event.", ex);
        }


    }
}
