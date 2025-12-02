using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taks1.Entites;

namespace Taks1.Persistence.EntitiesConfiguration;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
	public void Configure(EntityTypeBuilder<Invoice> builder)
	{
		builder.Property(x => x.DocumentType).IsRequired().HasMaxLength(1);
		builder.Property(x => x.DocumentTypeVersion).IsRequired().HasMaxLength(3);
		builder.Property(x => x.DateTimeIssued).IsRequired();
		builder.Property(x => x.InternalId).IsRequired().HasMaxLength(20);
		builder.Property(x => x.TotalSalesAmount).IsRequired().HasPrecision(15, 5);
		builder.Property(x => x.TotalDiscountAmount).IsRequired().HasPrecision(15, 5);
		builder.Property(x => x.TotalTaxAmount).IsRequired().HasPrecision(15, 5);
		builder.Property(x => x.TotalNetAmount).IsRequired().HasPrecision(15, 5);
		builder.Property(x => x.TotalAmount).IsRequired().HasPrecision(15, 5);
	}
}
