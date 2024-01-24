using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infraestructure.Persistence.Configurations;

public class ProjectConfigurations : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder.Property(p => p.TotalCost)
            .HasColumnType("decimal(18,2)");

        builder
            .HasOne(p => p.Freelancer)
            .WithMany(f => f.FreelanceProjects)
            .HasForeignKey(p => p.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder
            .HasOne(p => p.Client)
            .WithMany(f => f.OwnedProjects)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Restrict);
    }
}