namespace Taks1.Contracts.InoviceLine;

public record InvoiceLineResponse(string ItemName, decimal Quantity, decimal UnitPrice, decimal DiscountPercentage, decimal TaxPercentage, decimal NetTotal);
