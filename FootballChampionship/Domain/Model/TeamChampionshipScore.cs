
namespace FootballChampionship.Domain.Model
{
    public class TeamChampionshipScore
    {
        public int ChampionshipId { get; set; }
        public Championship Championship { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int? Score { get; set; }

        public int? Rating { get; set; }

    }
}
