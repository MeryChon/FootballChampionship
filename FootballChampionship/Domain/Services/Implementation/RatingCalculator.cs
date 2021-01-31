using FootballChampionship.Domain.Model;
using FootballChampionship.Domain.Services.Abstract;
using System;
using System.Collections.Generic;

namespace FootballChampionship.Domain.Services.Implementation
{
    public class RatingCalculator : IRatingCalculator
    {
        private const string INFORMATION = "Starting calculation of team ratings";

        private IRepository Repository;

        public RatingCalculator(IRepository repository)
        {
            Repository = repository;
        }

        public void ShowInformation()
        {
            Console.WriteLine(INFORMATION);
        }

        private static int TeamRatingComparator(TeamChampionshipScore tcs1, TeamChampionshipScore tcs2)
        {
            if (tcs1.Score is null || tcs2.Score is null)
            {
                throw new Exception("Cannot calculate ratings! One or more teams do not have scores set!");
            }

            int score1 = tcs1.Score ?? default;
            int score2 = tcs2.Score ?? default;
            if (score1 == score2)
            {
                string name1 = tcs1.Team.Name;
                string name2 = tcs2.Team.Name;
                return string.Compare(name1, name2, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                return score2 - score1;
            }
        }

        public void CalculateRating(int championshipId)
        {
            List<TeamChampionshipScore> teamScores = Repository.GetTeamsScoresForChampionship(championshipId);

            teamScores.Sort(TeamRatingComparator);

            for (int i = 0; i < teamScores.Count; i++)
            {
                teamScores[i].Rating = i + 1;
            }

            Repository.SaveTeamChampionshipRatings(championshipId, teamScores);
        }

        public void PrintRating(int championshipId)
        {
            List<TeamChampionshipScore> championshipRatings = Repository.GetChampionshipRatings(championshipId);
            Console.WriteLine("**************************************************************");
            Console.WriteLine("******************** Championship Ratings ********************");
            Console.WriteLine("**************************************************************");
            foreach (TeamChampionshipScore tcs in championshipRatings)
            {                
                Console.WriteLine(string.Format("{0}) {1} ({2} points)", tcs.Rating, tcs.Team.Name, tcs.Score));
            }
        }
    }
}
