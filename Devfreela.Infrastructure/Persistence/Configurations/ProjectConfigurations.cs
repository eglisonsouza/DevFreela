using Devfreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Devfreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            /*
            public string Title { get; private set; }
            public string Description { get; private set; }
            public int IdClient { get; private set; }
            public User Client { get; private set; }
            public int IdFreelancer { get; private set; }
            public User Freelancer { get; private set; }
            public decimal TotalCost { get; private set; }
            public DateTime CreatedAt { get; private set; }
            public DateTime? StartedAt { get; private set; }
            public DateTime? FinishedAt { get; private set; }
        */

            builder
                .Property(p => p.TotalCost).HasColumnType("Numeric");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(p => p.Freelancer)
                .WithMany(f => f.FreelanceProjects)
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Client)
                .WithMany(c => c.OwnedProjects)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
