using FootballChampionship.Domain.Model;
using System;
using System.Collections.Generic;

namespace FootballChampionship.Domain.Services.Implementation
{
    public class TeamCreator
    {

        private const string ENTER_NAME_HINT = "Enter team name (or hit enter to finish entering names):";
        private const string INSUFFICIENT_NUMBER_OF_TEAMS_WARNING = "We can not start championship with less than {0} teams.";
        private const string FINISH_ENTERING_TEAMS_CONFIRMATION = "Are you sure you want to finish entering team names? (y/n)";
        private const string DUPLICATE_TEAM_NAME_WARNING = "Team with name \"{0}\" already exists. Please enter unique name.";

        public int TeamsMinCount { get; }
        private readonly IRepository Repository;


        public TeamCreator(IRepository repository, int teamsMinCount = 5)
        {
            Repository = repository;
            TeamsMinCount = teamsMinCount;
        }

        public List<Team> CreateFromUserInput()
        {
            List<Team> result = new List<Team>();


            while (true)
            {
                Console.WriteLine(ENTER_NAME_HINT);
                string teamName = Console.ReadLine();

                if (string.IsNullOrEmpty(teamName))
                {
                    int count = Repository.GetTeamCount();
                    if (count < TeamsMinCount)
                    {
                        Console.WriteLine(String.Format(INSUFFICIENT_NUMBER_OF_TEAMS_WARNING, TeamsMinCount));
                    }
                    Console.WriteLine(FINISH_ENTERING_TEAMS_CONFIRMATION);

                    string response = Console.ReadLine();
                    if (!string.IsNullOrEmpty(response) && response.ToLower().Equals("y"))
                    {
                        break;
                    }
                }
                else
                {
                    Team newTeam = CreateNewTeam(teamName.Trim());
                    if (newTeam != null)
                    {
                        result.Add(newTeam);
                    }
                    else
                    {
                        Console.WriteLine(String.Format(DUPLICATE_TEAM_NAME_WARNING, teamName));
                    }

                }
            }

            return result;
        }

        private Team CreateNewTeam(string teamName)
        {
            try
            {
                return Repository.CreateNew(teamName);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
