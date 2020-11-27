using CheckerApp.Shared.Models.Commands;
using FluentValidation;

namespace CheckerApp.Shared.Validators
{
    public class UpdateContractCommandValidator : AbstractValidator<UpdateContractCommandVm>
    {
        public UpdateContractCommandValidator()
        {
            RuleFor(c => c.ContractNumber).NotEmpty().WithMessage("Не указан номер договора.");
            RuleFor(c => c.ProjectNumber).NotEmpty().WithMessage("Не указан внутренний номер проекта.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Не указано название договора.");
        }
    }
}
