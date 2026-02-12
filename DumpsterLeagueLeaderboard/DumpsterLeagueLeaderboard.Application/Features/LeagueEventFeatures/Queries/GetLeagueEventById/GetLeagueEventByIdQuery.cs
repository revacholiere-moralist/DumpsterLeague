using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetLeagueEventById;

public record GetLeagueEventByIdQuery(Guid Id) : IRequest<LeagueEventDto>;