using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Command.UpdatePlayer;
    
public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, PlayerDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlayerRepository _playerRepository;
    private readonly IPlayerQueryRepository _playerQueryRepository;

    public UpdatePlayerCommandHandler(
        IUnitOfWork unitOfWork,
        IPlayerRepository playerRepository)
    {
        _unitOfWork = unitOfWork;
        _playerRepository = playerRepository;
    }

    public async Task<PlayerDto> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        var existingPlayer = await _playerQueryRepository.GetByIdAsync(request.Request.PlayerId, true, cancellationToken);
        if (existingPlayer is null)
        {
            throw new Exception("Player does not exist.");
        }

        existingPlayer.UpdatedAt = DateTime.UtcNow;
        existingPlayer.CurrentDiscordId = request.Request.CurrentDiscordId;
        existingPlayer.CurrentDiscordName = request.Request.CurrentDiscordName;
        existingPlayer.CurrentIgn = request.Request.CurrentIgn;
        existingPlayer.CurrentPoints = request.Request.CurrentPoints;
        
        await _playerRepository.Update(existingPlayer);
        await _unitOfWork.Save(cancellationToken);
        
        return new PlayerDto
        {
            Id = existingPlayer.Id,
            CurrentDiscordId = existingPlayer.CurrentDiscordId,
            CurrentDiscordName = existingPlayer.CurrentDiscordName,
            CurrentIgn = existingPlayer.CurrentIgn,
            CurrentPoints = existingPlayer.CurrentPoints,
            CreatedAt = existingPlayer.CreatedAt,
            UpdatedAt = existingPlayer.UpdatedAt,
            IsActive = existingPlayer.IsActive
        };



    }
}
