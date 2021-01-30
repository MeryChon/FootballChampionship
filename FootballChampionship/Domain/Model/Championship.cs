using System.Collections.Generic;

namespace FootballChampionship.Domain.Model
{
    public class Championship
    {
        public int ChampionshipId { get; set; }
        public string Desciprtion { get; set; }
        public List<Match> Matches { get; set; }

        public ICollection<TeamChampionshipScore> TeamScores { get; set; }
    }
}
