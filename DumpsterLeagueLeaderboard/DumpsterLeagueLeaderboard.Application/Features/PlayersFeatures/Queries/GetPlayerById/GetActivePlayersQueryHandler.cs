using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Command.AddPlayer;
using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Responses;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Queries.GetActivePlayers;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Queries.GetPlayerById;

public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, PlayerDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlayerQueryRepository _playerQueryRepository;

    public GetPlayerByIdQueryHandler(
        IUnitOfWork unitOfWork,
        IPlayerQueryRepository playerQueryRepository)
    {
        _unitOfWork = unitOfWork;
        _playerQueryRepository = playerQueryRepository;
    }

    public async Task<PlayerDto> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        var player = await _playerQueryRepository.GetByIdAsync(request.Id, cancellationToken);
        return new PlayerDto
        {
            Id = player.Id,
            CurrentDiscordId = player.CurrentDiscordId,
            CurrentDiscordName = player.CurrentDiscordName,
            CurrentIgn = player.CurrentIgn,
            CurrentPoints = player.CurrentPoints,
            CreatedAt = player.CreatedAt,
            UpdatedAt = player.UpdatedAt,
            IsActive = player.IsActive
        };
    }
}
