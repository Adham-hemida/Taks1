using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taks1.Entites;

namespace Taks1.Persistence.EntitiesConfiguration;

public class ReceiverConfiguration : IEntityTypeConfiguration<Receiver>
{
	public void Configure(EntityTypeBuilder<Receiver> builder)
	{
		builder.Property(x => x.Name) .IsRequired().HasMaxLength(200);
		builder.Property(x => x.ResponsibleAuthority).IsRequired().HasMaxLength(100);
		builder.Property(x => x.Address).IsRequired().HasMaxLength(200);

		builder.HasData(new Receiver
		{
			Id = Guid.Parse("019addf3-0c6e-74e3-aff7-d10ce7ae2c08"),
			Name = "Ali Mohamed Ali",
			ResponsibleAuthority = "customer",
			Address = "Melig, Shebin-Elkom"
		});
	}
}
