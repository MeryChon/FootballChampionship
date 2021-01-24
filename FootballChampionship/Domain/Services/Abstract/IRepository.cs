using FootballChampionship.Domain.Model;

namespace FootballChampionship.Domain.Services
{
    public interface IRepository
    {
        Team CreateNew(string teamName);
        Match CreateNewMatch(Team firstTeam, Team secondTeam);
        MatchResult SaveMatchResult(int matchId, MatchResultType resultType, int? winningTeamId);
    }
}
