using System.ComponentModel.DataAnnotations.Schema;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Requests;

public class AddPlayerRequest
{
        public string CurrentDiscordId { get; set; } = "";
        public string CurrentDiscordName { get; set; } = "";
        public string CurrentIgn { get; set; } = "";
        public int CurrentPoints { get; set; } = 0;
}
