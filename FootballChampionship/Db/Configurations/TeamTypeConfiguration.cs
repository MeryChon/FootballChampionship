using FootballChampionship.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FootballChampionship.Db.Configurations
{
    class TeamTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);

            builder
                .HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}
