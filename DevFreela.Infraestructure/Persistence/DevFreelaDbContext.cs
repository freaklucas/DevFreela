using System.Reflection;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infraestructure.Persistence;

public class DevFreelaDbContext : DbContext
{
    public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) :base(options)
    {
        
    }
    public DbSet<Project> Projects { get; private set; }
    public DbSet<User> Users { get; private set; }
    public DbSet<Skill> Skills { get; private set; }
    public DbSet<Skill> UserSkills { get; private set; }
    public DbSet<ProjectComment> ProjectComments { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}