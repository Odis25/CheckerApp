using CheckerApp.Shared.Models.Hardware;
using FluentValidation;

namespace CheckerApp.Shared.Validators
{
    public class NetworkDeviceValidator : AbstractValidator<NetworkDeviceDto>
    {
        public NetworkDeviceValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            RuleFor(e => e.IP).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            RuleFor(e => e.MacAddress).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
        }
    }
}
