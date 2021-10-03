using FluentValidation;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
        }
    }
}