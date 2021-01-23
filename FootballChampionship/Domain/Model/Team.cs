using System.Collections.Generic;

namespace FootballChampionship.Domain.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public ICollection<Match> MathesAsFirst { get; set; }
        public ICollection<Match> MatchesAsSecond { get; set; }
    }
}
