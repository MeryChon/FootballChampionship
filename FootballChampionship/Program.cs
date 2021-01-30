using FootballChampionship.Db;
using FootballChampionship.Domain.Model;
using FootballChampionship.Domain.Services;
using FootballChampionship.Domain.Services.Implementation;
using System.Collections.Generic;

namespace FootballChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new Repository(new FootballChampionshipDbContext());
            int minNumTeams = 5;
            ChampionshipManager championshipManager = new ChampionshipManager(new TeamCreator(repository, minNumTeams),
                                                                                new MatchResultGatherer(repository),
                                                                                new ScoreCalculator(repository),
                                                                                repository);

            championshipManager.StartChampionship();
            championshipManager.GatherMatchResults();
            championshipManager.CalculateScores();
        }
    }
}
