using Taks1.Contracts.InoviceLine;
using Taks1.Entites;

namespace Taks1.Contracts.Inovice;

public record InvoiceResponse(Guid Id, string DocumentType, string DocumentTypeVersion, DateTime DateTimeIssued, string InternalId, Guid IssuerId, Guid ReceiverId, IList<InvoiceLineResponse> InvoiceLines, decimal TotalSalesAmount, decimal TotalDiscountAmount, decimal TotalTaxAmount, decimal TotalNetAmount, decimal TotalAmount);

