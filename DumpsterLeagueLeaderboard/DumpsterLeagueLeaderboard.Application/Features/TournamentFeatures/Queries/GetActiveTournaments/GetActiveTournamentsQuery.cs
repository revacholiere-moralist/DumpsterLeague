using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;

using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Queries.GetActiveTournaments;

public record GetActiveTournamentsQuery() : IRequest<List<TournamentDto>>;