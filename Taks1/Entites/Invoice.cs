namespace Taks1.Entites;

public class Invoice
{
	public Guid Id { get; set; } = Guid.CreateVersion7();
	public string DocumentType { get; set; } = string.Empty; // يجب أن يكون "i"
	public string DocumentTypeVersion { get; set; } = string.Empty; // يجب أن يكون "1.0"
	public DateTime DateTimeIssued { get; set; }// UTC، مش في المستقبل

	public string InternalId { get; set; } = string.Empty;
	public decimal TotalSalesAmount { get; set; }
	public decimal TotalDiscountAmount { get; set; }
	public decimal TotalNetAmount { get; set; }
	public decimal TotalTaxAmount { get; set; }
	public decimal TotalAmount { get; set; }

	public Guid IssuerId { get; set; } // مرتبط هنا
	public Issuer Issuer { get; set; } = default!; // مرتبط هنا

	public Guid ReceiverId { get; set; } // مرتبط هنا
	public Receiver Receiver { get; set; } = default!;// مرتبط هنا

	public ICollection<InvoiceLine> InvoiceLines { get; set; } = []; // مرتبط هنا (قائمة من InvoiceLine)
}
