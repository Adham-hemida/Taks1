namespace Taks1.Entites;

public class InvoiceLine
{
	public Guid Id { get; set; } = Guid.CreateVersion7();
	public string ItemName { get; set; } = string.Empty; 
	public string UnitType { get; set; } = string.Empty;
	public string? Description { get; set; } 
	public decimal Quantity { get; set; } 
	public decimal UnitPrice { get; set; } 
	public decimal DiscountPercentage { get; set; } = 0m;
	public decimal TaxPercentage { get; set; } = 0m;
	public string? TaxType { get; set; }

	public decimal SalesTotal => Math.Round(UnitPrice * Quantity, 5);
	public decimal CalculatedDiscount => Math.Round(SalesTotal * DiscountPercentage / 100, 5);
	public decimal NetTotal => Math.Round(SalesTotal- CalculatedDiscount,5); 
	public decimal TaxAmount => Math.Round(NetTotal * TaxPercentage / 100, 5);

	public Guid InvoiceId { get; set; }
	public Invoice Invoice { get; set; } = default!;
}