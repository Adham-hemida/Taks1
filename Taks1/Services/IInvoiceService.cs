
namespace Taks1.Services;

public interface IInvoiceService
{
	Task<Result<InvoiceResponse>> AddAsync(InvoiceRequest request, CancellationToken cancellationToken = default);
}
