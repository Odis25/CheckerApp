using FluentValidation;

namespace CheckerApp.Application.Softwares.Commands.CreateSoftware
{
    public class CreateSoftwareCommandValidator : AbstractValidator<CreateSoftwareCommand>
    {
        public CreateSoftwareCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
        }
    }
}
