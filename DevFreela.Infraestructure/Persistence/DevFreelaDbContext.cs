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
        modelBuilder.Entity<Project>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Freelancer)
            .WithMany(f => f.FreelanceProjects)
            .HasForeignKey(p => p.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.Client)
            .WithMany(f => f.OwnedProjects)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectComment>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<ProjectComment>()
            .HasOne(p => p.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdProject)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ProjectComment>()
            .HasOne(p => p.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Skill>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<User>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(u => u.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserSkill>()
            .HasKey(p => p.Id);
    }
}