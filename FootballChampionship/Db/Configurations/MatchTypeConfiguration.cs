using FootballChampionship.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballChampionship.Db.Configurations
{
    class MatchTypeConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(p => p.MatchId);

            builder.HasOne(m => m.FirstTeam)
                .WithMany(t => t.MatchesAsFirst)
                .HasForeignKey(m => m.FirstTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.SecondTeam)
                .WithMany(t => t.MatchesAsSecond)
                .HasForeignKey(m => m.SecondTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.Championship)
                .WithMany(c => c.Matches)
                .HasForeignKey(m => m.ChampionshipId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(m => m.ResultType)
                .HasConversion<int>();

            builder.HasOne(m => m.WinningTeam)
                .WithMany(t => t.MatchesAsWinner)
                .HasForeignKey(m => m.WinningTeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
