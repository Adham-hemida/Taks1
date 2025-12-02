namespace Taks1.Contracts.Inovice;

public record InvoiceRequest(string DocumentType, string DocumentTypeVersion, DateTime DateTimeIssued, string InternalId, Guid IssuerId, Guid ReceiverId,IList<InvoiceLineRequest> InvoiceLines);
