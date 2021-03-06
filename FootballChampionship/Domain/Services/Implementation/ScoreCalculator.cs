﻿using FootballChampionship.Domain.Model;
using FootballChampionship.Domain.Services.Abstract;
using System.Collections.Generic;

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
            List<Match> teamMatches = Repository.GetTeamMatchResults(teamId, championshipId);
            int score = 0;
            foreach (Match m in teamMatches)
            {
                if (m.ResultType == MatchResultType.VICTORY)
                {
                    score += (m.WinningTeamId == teamId) ? 3 : -1;
                }
            }

            return Repository.CreateTeamChampionshipResult(championshipId, teamId, score);
        }
    }
}
