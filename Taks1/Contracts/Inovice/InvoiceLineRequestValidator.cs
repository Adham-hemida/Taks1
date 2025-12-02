using FluentValidation;

namespace Taks1.Contracts.Inovice;

public class InvoiceLineRequestValidator : AbstractValidator<InvoiceLineRequest>
{
	public InvoiceLineRequestValidator()
	{
		RuleFor(x => x.ItemName)
			.NotEmpty()
			.WithMessage("ItemName is required.")
			.MaximumLength(50);

		RuleFor(x => x.UnitType)
			.NotEmpty()
			.WithMessage("UnitType is required.")
			.MaximumLength(20);

		RuleFor(x => x.Description)
			.MaximumLength(200)
			.When(x => !string.IsNullOrEmpty(x.Description));

		RuleFor(x => x.Quantity)
			.GreaterThan(0)
			.WithMessage("Quantity must be greater than zero.");

		RuleFor(x => x.UnitPrice)
			.GreaterThan(0)
			.WithMessage("UnitPrice must be greater than zero.");

		RuleFor(x => x.DiscountPercentage)
			.InclusiveBetween(0, 100)   //greater or equal than 0 and less or equal than 100
			.WithMessage("DiscountPercentage must be between 0 and 100.");

		RuleFor(x => x.TaxPercentage)
			.InclusiveBetween(0, 100)
			.WithMessage("TaxPercentage must be between 0 and 100.");

		RuleFor(x => x.TaxType)
			.MaximumLength(20)
			.When(x => !string.IsNullOrEmpty(x.TaxType));



	}
}
