using CheckerApp.Domain.Enums;
using FluentValidation;

namespace CheckerApp.Application.Hardwares.Commands.CreateHardware
{
    public class CreateHardwareCommandValidator : AbstractValidator<CreateHardwareCommand>
    {
        public CreateHardwareCommandValidator()
        {
            When(m => m.HardwareType == HardwareType.Cabinet, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.ConstructedBy).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.Pressure || m.HardwareType == HardwareType.Temperature, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.Flowmeter, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.FlowComputer, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.PLC, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.Valve, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
        }
    }
}
