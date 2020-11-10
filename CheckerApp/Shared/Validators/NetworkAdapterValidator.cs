using CheckerApp.Shared.Models.Hardware;
using FluentValidation;

namespace CheckerApp.Shared.Validators
{
    public class NetworkAdapterValidator : AbstractValidator<NetworkAdapterDto>
    {
        public NetworkAdapterValidator()
        {
            RuleFor(e => e.IP).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            RuleFor(e => e.MacAddress).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
        }
    }
}
