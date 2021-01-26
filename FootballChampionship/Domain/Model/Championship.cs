using System;
using System.Collections.Generic;
using System.Text;

namespace FootballChampionship.Domain.Model
{
    public class Championship
    {
        public int ChampionshipId { get; set; }
        public string Desciprtion { get; set; }
        public List<Match> Matches { get; set; }
    }
}
