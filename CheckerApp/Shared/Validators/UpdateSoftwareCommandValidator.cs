using CheckerApp.Shared.Models.Commands;
using FluentValidation;

namespace CheckerApp.Shared.Validators
{
    public class UpdateSoftwareCommandValidator : AbstractValidator<UpdateSoftwareCommandVm>
    {
        public UpdateSoftwareCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
        }
    }
}
