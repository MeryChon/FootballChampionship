using FootballChampionship.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FootballChampionship.Db.Configurations
{
    class TeamChampionshipScoreTypeConfiguration : IEntityTypeConfiguration<TeamChampionshipScore>
    {
        public void Configure(EntityTypeBuilder<TeamChampionshipScore> builder)
        {
            builder
                .HasOne(tcs => tcs.Championship)
                .WithMany(c => c.TeamScores)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(tcs => tcs.Team)
                .WithMany(t => t.ChampionshipScores)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
