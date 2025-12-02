using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taks1.Entites;

namespace Taks1.Persistence.EntitiesConfiguration;

public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
{
	public void Configure(EntityTypeBuilder<InvoiceLine> builder)
	{
		builder.Property(x => x.ItemName).IsRequired().HasMaxLength(50);
		builder.Property(x => x.Quantity).IsRequired().HasPrecision(15, 5);
		builder.Property(x => x.UnitType).IsRequired().HasMaxLength(20);
		builder.Property(x => x.Description).HasMaxLength(200);
		builder.Property(x => x.TaxType).HasMaxLength(50);
		builder.Property(x => x.UnitPrice).IsRequired().HasPrecision(15, 5);
		builder.Property(x => x.TaxPercentage).IsRequired().HasPrecision(15, 5);
		builder.Property(x => x.DiscountPercentage).IsRequired().HasPrecision(15, 5);
	}
}
