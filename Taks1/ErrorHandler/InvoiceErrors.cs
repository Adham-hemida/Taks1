using Taks1.Abstractions;
namespace Taks1.ErrorHandler;

public static class InvoiceErrors
{
	public static readonly Error issuerNottFound =
		new("issuer.not_found", "No issuer was found with the given Id", StatusCodes.Status404NotFound);

	public static readonly Error receiverNottFound =
		new("receiver.not_found", "No receiver was found with the given Id", StatusCodes.Status404NotFound);
	
	public static readonly Error TotalSalesAmount =
		new("TotalSalesAmount", "TotalSalesAmount should not be negative ", StatusCodes.Status404NotFound);
	
	public static readonly Error TotalNetAmount =
		new("TotalNetAmount", "TotalNetAmount should not be negative ", StatusCodes.Status404NotFound);
}
