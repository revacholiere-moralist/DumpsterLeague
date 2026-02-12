using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using MediatR;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Queries.GetPlayerById;

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
