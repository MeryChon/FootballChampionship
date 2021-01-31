using FootballChampionship.Db;
using FootballChampionship.Domain.Model;
using System;
using System.Collections;
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

        public Match SaveMatchResult(int matchId, MatchResultType resultType, Team winningTeam)
        {
            Match match = _dbContext.Set<Match>().Find(matchId);

            match.ResultType = resultType;
            match.WinningTeam = winningTeam;

            _dbContext.SaveChanges();

            return match;
        }

        public List<Match> GetTeamMatchResults(int teamId, int championshipId)
        {
            return _dbContext.Set<Match>()
                .Where(r => r.Championship.ChampionshipId == championshipId
                            && (r.FirstTeam.TeamId == teamId || r.SecondTeam.TeamId == teamId))
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
            TeamChampionshipScore entry = _dbContext.Set<TeamChampionshipScore>().Find(championshipId, teamId);

            if (entry is null)
            {
                entry = new TeamChampionshipScore
                {
                    ChampionshipId = championshipId,
                    TeamId = teamId,
                    Score = score
                };
                _dbContext.Add(entry);
            }
            else
            {
                entry.Score = score;
            }
            _dbContext.SaveChanges();
            return entry;
        }

        public List<TeamChampionshipScore> GetTeamsScoresForChampionship(int championshipId)
        {
            List<TeamChampionshipScore> result = _dbContext.Set<TeamChampionshipScore>()
                .Where(tcs => tcs.ChampionshipId == championshipId)
                .ToList();

            return result;
        }

        public void SaveTeamChampionshipRatings(int championshipId, List<TeamChampionshipScore> teamScores)
        {
            foreach (TeamChampionshipScore teamChampionshipScore in teamScores)
            {
                TeamChampionshipScore tcs = _dbContext.Set<TeamChampionshipScore>().Find(championshipId, teamChampionshipScore.TeamId);
                tcs.Rating = teamChampionshipScore.Rating;
            }

            _dbContext.SaveChanges();
        }

        public List<TeamChampionshipScore> GetChampionshipRatings(int championshipId)
        {
            return _dbContext.Set<TeamChampionshipScore>()
                .Where(tcs => tcs.ChampionshipId == championshipId)
                .OrderBy(tcs => tcs.Rating)
                .ToList();
        }
    }
}
