using FluentValidation;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
        }
    }
}