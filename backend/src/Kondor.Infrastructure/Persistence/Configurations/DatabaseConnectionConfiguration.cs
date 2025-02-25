using Kondor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kondor.Infrastructure.Persistence.Configurations;

public class DatabaseConnectionConfiguration : IEntityTypeConfiguration<DatabaseConnection>
{
    public void Configure(EntityTypeBuilder<DatabaseConnection> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.Host)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Port)
            .IsRequired();

        builder.Property(x => x.Database)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.IsEnabled)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        // Configuración para el Value Object ConnectionString
        builder.OwnsOne(x => x.ConnectionString, cs =>
        {
            cs.Property(p => p.Value)
                .HasColumnName("ConnectionString")
                .IsRequired()
                .HasMaxLength(500);
        });
    }
}