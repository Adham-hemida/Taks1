namespace Taks1.Contracts.Inovice;

public record InvoiceLineRequest(string ItemName, string UnitType,string? Description, decimal Quantity, decimal UnitPrice, decimal DiscountPercentage, decimal TaxPercentage, string? TaxType);
