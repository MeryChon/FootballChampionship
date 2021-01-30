using FootballChampionship.Domain.Model;
using FootballChampionship.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballChampionship.Domain.Services.Implementation
{
    public class ScoreCalculator : IScoreCalculator
    {
        private readonly IRepository Repository;

        public ScoreCalculator(IRepository repository)
        {
            Repository = repository;
        }

        public TeamChampionshipScore CalculateTeamScore(int teamId, int championshipId)
        {
            List<MatchResult> teamMatchResults = Repository.GetTeamMatchResults(teamId, championshipId);
            int score = 0;
            foreach (MatchResult r in teamMatchResults)
            {
                if (r.ResultType == MatchResultType.VICTORY)
                {
                    score += (r.WinningTeamId == teamId) ? 3 : -1;
                }
            }

            return Repository.CreateTeamChampionshipResult(championshipId, teamId, score);
        }
    }
}
