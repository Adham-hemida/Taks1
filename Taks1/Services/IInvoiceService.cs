using Taks1.Abstractions;
using Taks1.Contracts.Inovice;

namespace Taks1.Services;

public interface IInvoiceService
{
	Task<Result<InvoiceResponse>> AddAsync(InvoiceRequest request, CancellationToken cancellationToken = default);
}
