using FootballChampionship.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.SecondTeam)
                .WithMany(t => t.MatchesAsSecond)
                .HasForeignKey(m => m.SecondTeamId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
