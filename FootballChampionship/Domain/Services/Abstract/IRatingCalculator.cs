
namespace FootballChampionship.Domain.Services.Abstract
{
    public interface IRatingCalculator
    {
        public void ShowInformation();
        public void CalculateRating(int championshipId);
        public void PrintRating(int championshipId);
    }
}
