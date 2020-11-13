using CheckerApp.Shared.Models.Commands;
using FluentValidation;

namespace CheckerApp.Shared.Validators
{
    public class CreateSoftwareCommandValidator : AbstractValidator<CreateSoftwareCommandVm>
    {
        public CreateSoftwareCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
        }
    }
}
