using FootballChampionship.Domain.Model;
using System.Collections.Generic;

namespace FootballChampionship.Domain.Services
{
    public interface IRepository
    {
        Championship CreateNewChampionship();
        Team CreateNewTeam(string teamName);
        Match CreateNewMatch(Team firstTeam, Team secondTeam, Championship championship);
        MatchResult SaveMatchResult(int matchId, MatchResultType resultType, Team winningTeam);
        int GetTeamCount();
        List<Team> GetAllTeams();
        List<Match> GetAllMatches(int championshipId);
        List<MatchResult> GetTeamMatchResults(int teamId, int championshipId);
        TeamChampionshipScore CreateTeamChampionshipResult(int championshipId, int teamId, int score);
    }
}
