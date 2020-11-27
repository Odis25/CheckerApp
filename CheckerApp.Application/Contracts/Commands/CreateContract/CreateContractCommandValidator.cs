using FluentValidation;

namespace CheckerApp.Application.Contracts.Commands.CreateContract
{
    public class CreateContractCommandValidator : AbstractValidator<CreateContractCommand>
    {
        public CreateContractCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Это поле обязательно для заполнения");
            RuleFor(x => x.ContractNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения");
            RuleFor(x => x.ProjectNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения");
        }
    }
}
