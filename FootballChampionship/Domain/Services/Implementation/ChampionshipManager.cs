using FootballChampionship.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballChampionship.Domain.Services.Implementation
{
    public class ChampionshipManager
    {
        private const string GREETING_MESSAGE = "Welcome to University Football Championship management console.\nPlease enter names of participating teams.";

        private TeamCreator TeamCreator;
        private IRepository Repository;

        public ChampionshipManager(TeamCreator teamCreator, IRepository repository)
        {
            TeamCreator = teamCreator;
            Repository = repository;
        }

        public void StartChampionship()
        {
            Console.WriteLine(String.Format(GREETING_MESSAGE, TeamCreator.TeamsMinCount));

            List<Team> teams = TeamCreator.CreateFromUserInput();
            if (teams.Count >= TeamCreator.TeamsMinCount)
            {
                CreateMatches();
            }
        }

        private void CreateMatches()
        {

        }

        public void CouncludeChampionship()
        {

        }
    }
}
