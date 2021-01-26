using System.Collections.Generic;

namespace FootballChampionship.Domain.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }

        public ICollection<Match> MatchesAsFirst { get; set; }
        public ICollection<Match> MatchesAsSecond { get; set; }
        public ICollection<MatchResult> MatchResultVictories { get; set; }
    }
}
