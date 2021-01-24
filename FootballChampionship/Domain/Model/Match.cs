
namespace FootballChampionship.Domain.Model
{

    public class Match
    {
        public int MatchId { get; set; }

        public int FirstTeamId { get; set; }
        public virtual Team FirstTeam { get; set; }

        public int SecondTeamId { get; set; }
        public virtual Team SecondTeam { get; set; }

        public int? MatchResultId { get; set; }
        public MatchResult MatchResult { get; set; }
    }
}
