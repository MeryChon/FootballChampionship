
namespace FootballChampionship.Domain.Model
{
    public enum MatchResultType : int
    {
        VICTORY = 1,
        DRAW = 0
    }

    public class Match
    {
        public int MatchId { get; set; }

        public int ChampionshipId { get; set; }
        public Championship Championship { get; set; }

        public int FirstTeamId { get; set; }
        public virtual Team FirstTeam { get; set; }

        public int SecondTeamId { get; set; }
        public virtual Team SecondTeam { get; set; }

        public MatchResultType ResultType { get; set; }

        public int? WinningTeamId { get; set; }
        public Team WinningTeam { get; set; }
    }
}
