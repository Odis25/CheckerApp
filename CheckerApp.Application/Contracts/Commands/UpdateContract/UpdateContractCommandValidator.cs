using FluentValidation;

namespace CheckerApp.Application.Contracts.Commands.UpdateContract
{
    public class UpdateContractCommandValidator : AbstractValidator<UpdateContractCommand>
    {
        public UpdateContractCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Это поле обязательно для заполнения");
            RuleFor(x => x.ContractNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения");
            RuleFor(x => x.ProjectNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения");
        }
    }
}
