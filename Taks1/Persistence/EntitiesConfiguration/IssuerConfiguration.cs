using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taks1.Entites;

namespace Taks1.Persistence.EntitiesConfiguration;

public class IssuerConfiguration : IEntityTypeConfiguration<Issuer>
{
	public void Configure(EntityTypeBuilder<Issuer> builder)
	{
		builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
		builder.Property(x => x.ResponsibleAuthority).IsRequired().HasMaxLength(100);
		builder.Property(x => x.Address).IsRequired().HasMaxLength(200);

		builder.HasData(new Issuer
		{
			Id = Guid.Parse("019addf3-0c6e-74e3-aff7-d10bc7f69e06"),
			Name = "Adham Said Hemdia",
			ResponsibleAuthority = "Fox Shop",
			Address = "123 St, Shebin-Elkom, Egypt"
		});
		

	}
}
