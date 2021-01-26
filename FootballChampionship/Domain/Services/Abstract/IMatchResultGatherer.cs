using FootballChampionship.Domain.Model;

namespace FootballChampionship.Domain.Services.Abstract
{
    public interface IMatchResultGatherer
    {
        public void InformUser();
        public void CreateMatchResultFromUserInput(Match match);
    }
}
