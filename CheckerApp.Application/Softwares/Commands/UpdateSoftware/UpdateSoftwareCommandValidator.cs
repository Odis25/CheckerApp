using FluentValidation;

namespace CheckerApp.Application.Softwares.Commands.UpdateSoftware
{
    public class UpdateSoftwareCommandValidator : AbstractValidator<UpdateSoftwareCommand>
    {
        public UpdateSoftwareCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
        }
    }
}
