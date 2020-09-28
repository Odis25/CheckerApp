using FluentValidation;

namespace CheckerApp.Shared.Contract
{
    public class CreateContractVmValidator : AbstractValidator<CreateContractVm>
    {
        public CreateContractVmValidator()
        {
            RuleFor(c => c.ContractNumber).NotEmpty().WithMessage("Не указан номер договора.");
            RuleFor(c => c.DomesticNumber).NotEmpty().WithMessage("Не указан внутренний номер договора.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Не указан название договора.");
        }
    }
}
