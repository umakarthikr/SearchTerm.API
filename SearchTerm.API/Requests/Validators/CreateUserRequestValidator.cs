using FluentValidation;
using SearchTerm.API.Requests.Model;

namespace SearchTerm.API.Requests.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator() {
            RuleFor(r => r.First_Name)
              .NotEmpty()
              .NotNull()
              .WithMessage("First name is required");

            RuleFor(r => r.Last_Name)
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
