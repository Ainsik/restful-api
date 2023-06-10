using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configuration.Entities;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(a => a.Street)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(a => a.PostalCode)
            .IsRequired()
            .HasMaxLength(6)
            .IsFixedLength();
    }
}