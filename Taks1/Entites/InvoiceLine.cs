namespace Taks1.Entites;

public class InvoiceLine
{
	public Guid Id { get; set; } = Guid.CreateVersion7();
	public string ItemName { get; set; } = string.Empty; // اسم الصنف
	public string UnitType { get; set; } = string.Empty;// نوع الوحدة (زي "EA" للقطعة، أو "KG" للكيلو)
	public string? Description { get; set; } // وصف الصنف
	public decimal Quantity { get; set; } // الكمية (decimal عشان الدقة، مش int)
	public decimal UnitPrice { get; set; } // قيمة الوحدة (سعر الوحدة)
	public decimal DiscountPercentage { get; set; } = 0m;
	public decimal TaxPercentage { get; set; } = 0m;
	public string? TaxType { get; set; }

	public decimal SalesTotal => Math.Round(UnitPrice * Quantity, 5);// إجمالي المبيعات لهذا السطر (Quantity * UnitValue)
	public decimal CalculatedDiscount => Math.Round(SalesTotal * DiscountPercentage / 100, 5);
	public decimal NetTotal => Math.Round(SalesTotal- CalculatedDiscount,5); // الصافي بعد الخصم
	public decimal TaxAmount => Math.Round(NetTotal * TaxPercentage / 100, 5);

	public Guid InvoiceId { get; set; }
	public Invoice Invoice { get; set; } = default!;
}