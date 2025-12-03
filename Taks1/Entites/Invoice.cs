namespace Taks1.Entites;

public class Invoice
{
	public Guid Id { get; set; } = Guid.CreateVersion7();
	public string DocumentType { get; set; } = string.Empty; 
	public string DocumentTypeVersion { get; set; } = string.Empty; 
	public DateTime DateTimeIssued { get; set; }

	public string InternalId { get; set; } = string.Empty;
	public decimal TotalSalesAmount { get; set; }
	public decimal TotalDiscountAmount { get; set; }
	public decimal TotalNetAmount { get; set; }
	public decimal TotalTaxAmount { get; set; }
	public decimal TotalAmount { get; set; }

	public Guid IssuerId { get; set; } 
	public Issuer Issuer { get; set; } = default!; 

	public Guid ReceiverId { get; set; }
	public Receiver Receiver { get; set; } = default!;

	public ICollection<InvoiceLine> InvoiceLines { get; set; } = []; 
}
