using FluentValidation;
using SearchTerm.API.Requests.Model;

namespace SearchTerm.API.Requests.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator() {
            RuleFor(r => r.FirstName)
              .NotEmpty()
              .NotNull()
              .WithMessage("First name is required");

            RuleFor(r => r.LastName)
              .NotEmpty()
              .NotNull()
              .WithMessage("Last name is required");

            RuleFor(r => r.Email)
              .NotEmpty()
              .NotNull()
              .WithMessage("Email is required");

            RuleFor(r => r.Gender)
              .NotEmpty()
              .NotNull()
              .WithMessage("Gender is required");
        }
    }
}
