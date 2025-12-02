using Microsoft.AspNetCore.Mvc;
using Taks1.Abstractions;
using Taks1.Contracts.Inovice;
using Taks1.Services;

namespace Taks1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class InvoicesController(IInvoiceService invoiceService) : ControllerBase
{
	private readonly IInvoiceService _invoiceService = invoiceService;

	[HttpPost]
	public async Task<IActionResult> CreateInvoiceAsync([FromBody] InvoiceRequest request, CancellationToken cancellationToken)
	{
		var result = await _invoiceService.AddAsync(request, cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}
}
