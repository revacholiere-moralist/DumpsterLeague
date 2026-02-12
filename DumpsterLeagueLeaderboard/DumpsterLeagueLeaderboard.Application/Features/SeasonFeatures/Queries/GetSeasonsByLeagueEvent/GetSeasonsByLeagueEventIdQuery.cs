using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Responses;
using DumpsterLeagueLeaderboard.Domain.Entities;
using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Queries.GetSeasonsByLeagueEvent;

public record GetSeasonsByLeagueEventIdQuery(Guid LeagueEventId) : IRequest<List<SeasonDto>>;