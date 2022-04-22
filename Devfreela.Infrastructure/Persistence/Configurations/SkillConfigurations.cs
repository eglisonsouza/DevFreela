using Devfreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devfreela.Infrastructure.Persistence.Configurations
{
    public class SkillConfigurations : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.Id).ValueGeneratedOnAdd();

            builder
                .Property(s => s.CreatedAt).HasDefaultValue(DateTime.Now).IsRequired();

            builder
                .Property(s => s.Description).HasMaxLength(50).IsRequired();
        }
    }
}
