using Devfreela.Core.Entities;
using DevFreela.Shared.Models.UI;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Devfreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        private readonly ConnectionDatabase _connectionDatabase;

        public DevFreelaDbContext(ApiSettings apiSettings)
        {
            _connectionDatabase = apiSettings.ConnectionDatabase;
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionDatabase.DevFreela, new MySqlServerVersion(new Version(5, 7)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
