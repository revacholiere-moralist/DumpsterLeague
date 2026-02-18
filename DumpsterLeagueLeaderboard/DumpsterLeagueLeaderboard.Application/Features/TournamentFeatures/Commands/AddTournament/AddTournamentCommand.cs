using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Requests;
using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;
using MediatR;

namespace DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Commands.AddTournament;

public record AddTournamentCommand(AddTournamentRequest Request) : IRequest<TournamentDto>;