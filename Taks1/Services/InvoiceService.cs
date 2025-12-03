using Taks1.Contracts.InoviceLine;
using Taks1.ErrorHandler;
using Taks1.Persistence.Data;

namespace Taks1.Services;

public class InvoiceService(ApplicationDbContext context) : IInvoiceService
{
	private readonly ApplicationDbContext _context = context;

	public async Task<Result<InvoiceResponse>> AddAsync(InvoiceRequest request, CancellationToken cancellationToken = default)
	{
		var issuerIsExist= await _context.Issuers.AnyAsync(i=>i.Id==request.IssuerId,cancellationToken);
		if (!issuerIsExist)
			return Result.Failure<InvoiceResponse>(InvoiceErrors.issuerNottFound);

		var receiverIsExist= await _context.Receivers.AnyAsync(i => i.Id == request.ReceiverId, cancellationToken);
		if (!receiverIsExist)
			return Result.Failure<InvoiceResponse>(InvoiceErrors.receiverNottFound);


		var invoice = request.Adapt<Invoice>();

		var totalResult= CalculateTotals(invoice);
		if (!totalResult.IsSuccess)
			return Result.Failure<InvoiceResponse>(totalResult.Error);

		_context.Invoices.Add(invoice);
		await _context.SaveChangesAsync(cancellationToken);

		var response = new InvoiceResponse(
	  invoice.Id,
	  invoice.DocumentType,
	  invoice.DocumentTypeVersion,
	  invoice.DateTimeIssued,
	  invoice.InternalId,
	  invoice.IssuerId,
	  invoice.ReceiverId,
	  invoice.InvoiceLines.Select(x => new InvoiceLineResponse(
		  x.ItemName,
		  x.Quantity,
		  x.UnitPrice,
		  x.DiscountPercentage,
		  x.TaxPercentage,
		  x.NetTotal
		
	  )).ToList(),
	  invoice.TotalSalesAmount,
	  invoice.TotalDiscountAmount,
	  invoice.TotalTaxAmount,
	  invoice.TotalNetAmount,
	  invoice.TotalAmount
  );

		return Result.Success(response);


	}

	private  Result CalculateTotals(Invoice invoice)
	{
		invoice.TotalSalesAmount = Math.Round(invoice.InvoiceLines.Sum(x => x.SalesTotal),5);

		if (invoice.TotalSalesAmount < 0)
			return Result.Failure(InvoiceErrors.TotalSalesAmount);

		invoice.TotalDiscountAmount = Math.Round(invoice.InvoiceLines.Sum(x => x.CalculatedDiscount),5);

		invoice.TotalNetAmount = Math.Round(invoice.InvoiceLines.Sum(x => x.NetTotal),5);

		if (invoice.TotalNetAmount < 0)
			return Result.Failure(InvoiceErrors.TotalNetAmount);

		invoice.TotalTaxAmount = Math.Round(invoice.InvoiceLines.Sum(x => x.TaxAmount),5);
		invoice.TotalAmount = Math.Round(invoice.TotalNetAmount + invoice.TotalTaxAmount, 5);

		return Result.Success();
	}

}
