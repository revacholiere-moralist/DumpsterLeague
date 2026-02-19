using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Command.AddPlayer;
    
public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, PlayerDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlayerRepository _playerRepository;

    public AddPlayerCommandHandler(
        IUnitOfWork unitOfWork,
        IPlayerRepository playerRepository)
    {
        _unitOfWork = unitOfWork;
        _playerRepository = playerRepository;
    }

    public async Task<PlayerDto> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Player
        {
            CurrentDiscordId = request.Request.CurrentDiscordId,
            CurrentDiscordName = request.Request.CurrentDiscordName,
            CurrentIgn = request.Request.CurrentIgn,
            CurrentPoints = request.Request.CurrentPoints,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsActive = true
        };

        var addedPlayer = await _playerRepository.AddAsync(player);

        try
        {
            await _unitOfWork.Save(cancellationToken);
            return new PlayerDto
            {
                Id = addedPlayer.Id,
                CurrentDiscordId = addedPlayer.CurrentDiscordId,
                CurrentDiscordName = addedPlayer.CurrentDiscordName,
                CurrentIgn = addedPlayer.CurrentIgn,
                CurrentPoints = addedPlayer.CurrentPoints,
                CreatedAt = addedPlayer.CreatedAt,
                UpdatedAt = addedPlayer.UpdatedAt,
                IsActive = addedPlayer.IsActive
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
