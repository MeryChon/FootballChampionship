﻿
namespace FootballChampionship.Domain.Model
{
    public class TeamChampionshipScore
    {
        public int TeamChampionshipScoreId { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int Score { get; set; }

    }
}