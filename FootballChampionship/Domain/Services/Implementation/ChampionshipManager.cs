using FootballChampionship.Domain.Model;
using FootballChampionship.Domain.Services.Abstract;
using System;
using System.Collections.Generic;

namespace FootballChampionship.Domain.Services.Implementation
{
    public class ChampionshipManager
    {
        private const string GREETING_MESSAGE = "Welcome to University Football Championship management console.\nPlease enter names of participating teams.";

        private readonly TeamCreator TeamCreator;
        private readonly IMatchResultGatherer MatchResultGatherer;
        private readonly IScoreCalculator ScoreCalculator;
        private readonly IRepository Repository;
        private Championship CurrentChampionship;

        public ChampionshipManager(TeamCreator teamCreator, IMatchResultGatherer matchResultGatherer, IScoreCalculator scoreCalculator, IRepository repository)
        {
            TeamCreator = teamCreator;
            MatchResultGatherer = matchResultGatherer;
            ScoreCalculator = scoreCalculator;
            Repository = repository;
        }

        public void StartChampionship()
        {
            CreateChampionshipObject();
            Console.WriteLine(String.Format(GREETING_MESSAGE, TeamCreator.TeamsMinCount));

            TeamCreator.CreateFromUserInput();
            int teamsCount = Repository.GetTeamCount();
            if (teamsCount >= TeamCreator.TeamsMinCount)
            {
                CreateMatches();
            }
        }

        private void CreateChampionshipObject()
        {
            CurrentChampionship = Repository.CreateNewChampionship();
        }

        private void CreateMatches()
        {
            List<Team> teams = Repository.GetAllTeams();
            foreach (Team t1 in teams)
            {
                foreach (Team t2 in teams)
                {
                    if (t1.TeamId != t2.TeamId)
                    {
                        try
                        {
                            Repository.CreateNewMatch(t1, t2, CurrentChampionship);  // TODO should implement batch create?
                        }
                        catch (Exception ignored)
                        {

                        }
                    }
                }
            }
        }

        public void GatherMatchResults()
        {
            MatchResultGatherer.InformUser();

            List<Match> allMatches = Repository.GetAllMatches(CurrentChampionship.ChampionshipId);
            foreach (Match m in allMatches)
            {
                MatchResultGatherer.CreateMatchResultFromUserInput(m);
            }
        }

        public void CalculateScores()
        {
            List<Team> allTeams = Repository.GetAllTeams();
            foreach(Team team in allTeams)
            {
                ScoreCalculator.CalculateTeamScore(team.TeamId, CurrentChampionship.ChampionshipId);
            }

        }
    }
}
