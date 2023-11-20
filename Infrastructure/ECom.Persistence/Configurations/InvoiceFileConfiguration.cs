using ECom.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECom.Persistence.Configurations;

public class InvoiceFileConfiguration : IEntityTypeConfiguration<InvoiceFile>
{
    public void Configure(EntityTypeBuilder<InvoiceFile> builder)
    {
        builder.Property(x => x.Price).IsRequired().HasPrecision(14, 2);
    }
}