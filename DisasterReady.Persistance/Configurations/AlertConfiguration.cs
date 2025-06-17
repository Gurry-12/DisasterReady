using DisasterReady.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DisasterReady.Persistence.Configurations
{
    public class AlertConfiguration : IEntityTypeConfiguration<Alert>
    {
        public void Configure(EntityTypeBuilder<Alert> builder)
        {
            builder.ToTable("Alerts");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Location)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Message)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(a => a.SeverityLevel)
                .IsRequired();

            builder.Property(a => a.Region)
                .IsRequired();

            builder.Property(a => a.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(a => a.Source)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("System");

            // Indexes
            builder.HasIndex(a => a.SeverityLevel);

            builder.HasIndex(a => a.Region);

            builder.HasIndex(a => a.IsActive);

            builder.HasIndex(a => a.CreatedAt);

            builder.HasIndex(a => a.DisasterTypeId);

            // Relationships
            builder.HasOne(a => a.DisasterType)
                .WithMany(dt => dt.Alerts)
                .HasForeignKey(a => a.DisasterTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 