using FluentValidation;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage(ValidationMessages.InvalidAddress);
        }
    }
}