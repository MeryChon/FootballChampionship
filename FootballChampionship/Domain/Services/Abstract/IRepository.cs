using FootballChampionship.Domain.Model;
using System.Collections.Generic;

namespace FootballChampionship.Domain.Services
{
    public interface IRepository
    {
        Championship CreateNewChampionship();
        Team CreateNewTeam(string teamName);
        Match CreateNewMatch(Team firstTeam, Team secondTeam, Championship championship);
        Match SaveMatchResult(int matchId, MatchResultType resultType, Team winningTeam);
        int GetTeamCount();
        List<Team> GetAllTeams();
        List<Match> GetAllMatches(int championshipId);
        List<Match> GetTeamMatchResults(int teamId, int championshipId);
        TeamChampionshipScore CreateTeamChampionshipResult(int championshipId, int teamId, int score);
        List<TeamChampionshipScore> GetTeamsScoresForChampionship(int championshipId);
        void SaveTeamChampionshipRatings(int championshipId, List<TeamChampionshipScore> teamScores);
        List<TeamChampionshipScore> GetChampionshipRatings(int championshipId);
    }
}
