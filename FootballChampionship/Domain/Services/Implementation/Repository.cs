using FootballChampionship.Db;
using FootballChampionship.Domain.Model;
using System;
using System.Collections.Generic;
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


        // ---------------- Teams
        public Team CreateNewTeam(string name)
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

        public int GetTeamCount()
        {
            return _dbContext.Set<Team>().Count();
        }


        public List<Team> GetAllTeams()
        {
            return _dbContext.Set<Team>().ToList();
        }


        public List<int> GetAllTeamIds()
        {
            return _dbContext.Set<Team>().Select(t => t.TeamId).ToList();
        }


        // ---------------- Matches

        public Match CreateNewMatch(Team firstTeam, Team secondTeam, Championship championship)
        {
            var count = _dbContext.Set<Match>().Count(m => (m.ChampionshipId == championship.ChampionshipId
                                                            && (m.FirstTeamId == firstTeam.TeamId && m.SecondTeamId == secondTeam.TeamId)
                                                                    || (m.FirstTeamId == secondTeam.TeamId && m.SecondTeamId == firstTeam.TeamId)));

            if (count > 0)
            {
                throw new Exception("Match for these teams already exists.");
            }

            Match newMatch = new Match
            {
                FirstTeam = firstTeam,
                SecondTeam = secondTeam,
                Championship = championship,
            };
            _dbContext.Add<Match>(newMatch);
            _dbContext.SaveChanges();

            return newMatch;
        }

        public List<Match> GetAllMatches(int championshipId)
        {
            return _dbContext.Set<Match>()
                .Where(m => m.Championship.ChampionshipId == championshipId)
                .OrderBy(m => m.FirstTeam.Name)
                .ThenBy(m => m.SecondTeam.Name)
                .ToList();
        }

        // ---------------- Match Results

        public MatchResult SaveMatchResult(int matchId, MatchResultType resultType, Team winningTeam)
        {
            MatchResult matchResult;
            int count = _dbContext.Set<MatchResult>().Count(r => r.MatchId == matchId);

            if (count > 0)
            {
                matchResult = _dbContext.Set<MatchResult>().Single(r => r.MatchId == matchId);
                matchResult.ResultType = resultType;
                matchResult.WinningTeam = winningTeam;
            }
            else
            {
                matchResult = new MatchResult
                {
                    MatchId = matchId,
                    WinningTeam = winningTeam,
                };

                _dbContext.Add<MatchResult>(matchResult);
            }

            _dbContext.SaveChanges();

            return matchResult;
        }

        public List<MatchResult> GetTeamMatchResults(int teamId, int championshipId)
        {
            List<MatchResult> all = _dbContext.Set<MatchResult>().ToList();

            return _dbContext.Set<MatchResult>()
                .Where(r => r.Match.Championship.ChampionshipId == championshipId
                            && (r.Match.FirstTeam.TeamId == teamId || r.Match.SecondTeam.TeamId == teamId))
                .ToList();
        }

        // ---------------- Championships

        public Championship CreateNewChampionship()
        {
            Championship c = new Championship();
            c.Desciprtion = "This is a new championship";
            _dbContext.Set<Championship>().Add(c);
            _dbContext.SaveChanges();

            return c;
        }

        public TeamChampionshipScore CreateTeamChampionshipResult(int championshipId, int teamId, int score)
        {
            throw new NotImplementedException();
        }
    }
}
