using DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Queries.GetActiveLeagueEvents;

public record GetActiveLeagueEventQuery() : IRequest<List<LeagueEventDto>>;