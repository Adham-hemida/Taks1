using System.Reflection;

namespace Taks1.Persistence.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
	public DbSet<InvoiceLine> InvoiceLines { get; set; } = default!;
	public DbSet<Invoice> Invoices { get; set; } = default!;
	public DbSet<Receiver> Receivers { get; set; } = default!;
	public DbSet<Issuer> Issuers { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());

		base.OnModelCreating(modelBuilder);
	}
}
