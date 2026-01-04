using FluentValidation;
using CashFlow.Communication.Requests;

namespace CashFlow.Communication.Requests;

public class RegisterExpenseValidator : AbstractValidator<RequestExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must be at most 100 characters long.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0.");

        RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Date cannot be in the future.")
            .Must(BeAValidDate).WithMessage("Date is not valid.");

        RuleFor(x => x.PaymentType)
            .IsInEnum().WithMessage("Payment method is not valid.");
    }

    private bool BeAValidDate(DateTime date)
    {
        return date != default;
    }
}