using FootballChampionship.Db;
using FootballChampionship.Domain.Model;
using System;
using System.Linq;

namespace FootballChampionship.Domain.Services.Implementation
{
    public class Repository : IRepository
    {
        private readonly FootballChampionshipDbContext _dbContext;

        public Repository(FootballChampionshipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Match CreateNewMatch(Team firstTeam, Team secondTeam)
        {
            var count = _dbContext.Set<Match>().Count(m => (m.FirstTeamId == firstTeam.TeamId && m.SecondTeamId == secondTeam.TeamId)
            || (m.FirstTeamId == secondTeam.TeamId && m.SecondTeamId == firstTeam.TeamId));

            if (count > 0)
            {
                throw new Exception("Match for these teams already exists.");
            }

            Match newMatch = new Match
            {
                FirstTeam = firstTeam,
                SecondTeam = secondTeam,
            };
            _dbContext.Add<Match>(newMatch);
            _dbContext.SaveChanges();

            return newMatch;
        }

        public Team CreateNew(string name)
        {
            int numTeamsWithName = _dbContext.Set<Team>().Count(t => t.Name == name);
            if (numTeamsWithName > 0)
            {
                throw new Exception("Team with name " + name + "already exists!");
            }

            Team newTeam = new Team
            {
                Name = name
            };
            _dbContext.Add<Team>(newTeam);
            _dbContext.SaveChanges();

            return newTeam;
        }


        public MatchResult SaveMatchResult(int matchId, MatchResultType resultType, int? winningTeamId)
        {
            MatchResult matchResult = _dbContext.Set<MatchResult>().Single(r => r.MatchId == matchId);

            if (matchResult != null)
            {
                matchResult.ResultType = resultType;
                matchResult.WinningTeamId = winningTeamId;
            }
            else
            {
                matchResult = new MatchResult
                {
                    MatchId = matchId,
                    WinningTeamId = winningTeamId
                };

                _dbContext.Add<MatchResult>(matchResult);
            }

            _dbContext.SaveChanges();

            return matchResult;
        }
    }
}
