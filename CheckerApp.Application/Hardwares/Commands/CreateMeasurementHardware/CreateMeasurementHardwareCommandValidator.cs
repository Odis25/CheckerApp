using FluentValidation;

namespace CheckerApp.Application.Hardwares.Commands.CreateMeasurementHardware
{
    public class CreateMeasurementHardwareCommandValidator : AbstractValidator<CreateMeasurementHardwareCommand>
    {
        public CreateMeasurementHardwareCommandValidator()
        {
            RuleFor(c => c.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения");
            RuleFor(c => c.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения");
        }
    }
}
