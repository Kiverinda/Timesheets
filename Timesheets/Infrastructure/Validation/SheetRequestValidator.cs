using FluentValidation;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class SheetRequestValidator : AbstractValidator<SheetRequest>
    {
        public SheetRequestValidator()
        {
            RuleFor(x => x.Amount)
                .InclusiveBetween(1, 8)
                .WithMessage(ValidationMessages.SheetAmountError);
            RuleFor(x => x.EmployeeId)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
            RuleFor(x => x.ContractId)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
            RuleFor(x => x.ServiceId)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
        }
    }
}