using FootballChampionship.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballChampionship.Db.Configurations
{
    class MatchResultTypeConfiguration : IEntityTypeConfiguration<MatchResult>
    {
        public void Configure(EntityTypeBuilder<MatchResult> builder)
        {
            builder
                .HasOne(r => r.Match)
                .WithOne(m => m.MatchResult)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<Match>(m => m.MatchResultId);
        }
    }
}
