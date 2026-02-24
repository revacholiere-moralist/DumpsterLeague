using DumpsterLeagueLeaderboard.Application.Exceptions;
using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Domain.Entities;

using MediatR;
using Microsoft.Extensions.Logging;

namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Commands.AddLeagueEvent;
public class AddLeagueEventCommandHandler : IRequestHandler<AddLeagueEventCommand, LeagueEventDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILeagueEventRepository _leagueEventRepository;
    private readonly ILogger<AddLeagueEventCommandHandler> _logger;


    public AddLeagueEventCommandHandler(
        IUnitOfWork unitOfWork,
        ILeagueEventRepository leagueEventRepository,
        ILogger<AddLeagueEventCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _leagueEventRepository = leagueEventRepository;
        _logger = logger;
    }

    public async Task<LeagueEventDto> Handle(AddLeagueEventCommand request, CancellationToken cancellationToken)
    {
        
        var leagueEvent = new LeagueEvent
        {
            EventName = request.Request.EventName,
            IsOngoing = request.Request.IsOngoing,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };

        var addedLeagueEvent = await _leagueEventRepository.AddAsync(leagueEvent);

        try
        {
            await _unitOfWork.Save(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new DatabaseException(string.Format("exception occurred during League Event Creation: {0}", ex.Message));
        }

        return new LeagueEventDto
        {
            Id = addedLeagueEvent.Id,
            EventName = addedLeagueEvent.EventName,
            IsOngoing = addedLeagueEvent.IsOngoing,
            CreatedAt = addedLeagueEvent.CreatedAt,
            UpdatedAt = addedLeagueEvent.UpdatedAt,
            IsActive = addedLeagueEvent.IsActive
        };
    }
}
