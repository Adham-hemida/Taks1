using FluentValidation;

namespace Taks1.Contracts.Inovice;

public class InvoiceRequestValidator : AbstractValidator<InvoiceRequest>
{
	public InvoiceRequestValidator()
	{
		RuleFor(x => x.DocumentType)
			.NotEmpty()
			.WithMessage("DocumentType is required")
			.Equal("i")
			.WithMessage("DocumentType must be i");

		RuleFor(x => x.DocumentTypeVersion)
			.NotEmpty()
			.WithMessage("DocumentTypeVersion is required")
			.Equal("1.0")
			.WithMessage("DocumentTypeVersion must be 1.0");


		RuleFor(x => x.DateTimeIssued)
			.NotEmpty()
			.WithMessage("DateTimeIssued is required")
			.LessThanOrEqualTo(DateTime.UtcNow)
			.WithMessage("DateTimeIssued cannot be in the future");

		RuleFor(x => x.InternalId)
			.NotEmpty()
			.WithMessage("InternalId is required")
			.MaximumLength(20);

		RuleFor(x => x.IssuerId)
			.NotEmpty()
			.WithMessage("IssuerId is required");

		RuleFor(x => x.ReceiverId)
			.NotEmpty()
			.WithMessage("ReceiverId is required");

		RuleFor(x => x.InvoiceLines)
			.NotNull()
			.NotEmpty();


		RuleFor(x => x.InvoiceLines)
			.Must(x => x.Count > 0)
			.WithMessage("InvoiceLines should have at least 1 InvoiceLines")
			.When(x => x.InvoiceLines != null);

		RuleForEach(x => x.InvoiceLines)
			.SetInheritanceValidator(v => v.Add(
				new InvoiceLineRequestValidator()
				));

	}

}
