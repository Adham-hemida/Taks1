using Taks1.Contracts.Inovice;

namespace Taks1.Mapping;

public class MappingConfiguaration : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		TypeAdapterConfig<InvoiceLineRequest, InvoiceLine>.NewConfig();

		TypeAdapterConfig<InvoiceRequest, Invoice>.NewConfig()
			.Map(dest => dest.InvoiceLines, src => src.InvoiceLines); 
	}
}
