using FootballChampionship.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballChampionship.Domain.Services.Abstract
{
    public interface IScoreCalculator
    {
        public TeamChampionshipScore CalculateTeamScore(int teamId, int championshipId);
    }
}
