
namespace FootballChampionship.Domain.Model
{
    public class MatchResult
    {
        public int MatchResultId { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }
        
        public MatchResultType ResultType { get; set; }
        
        public int? WinningTeamId { get; set; }
        public Team WinningTeam { get; set; }
    }
}
