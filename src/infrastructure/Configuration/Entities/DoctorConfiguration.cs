using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configuration.Entities;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasOne(a => a.Address)
            .WithOne(d => d.Doctor)
            .HasForeignKey<Address>(d => d.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Phone)
            .IsRequired()
            .HasMaxLength(9)
            .IsFixedLength();

        builder.Property(p => p.Specialization)
            .IsRequired()
            .HasMaxLength(50);
    }
}