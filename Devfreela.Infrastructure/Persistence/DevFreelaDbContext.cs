using Devfreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Devfreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DevFreelaDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DevFreela"), new MySqlServerVersion(new Version(5, 7)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
