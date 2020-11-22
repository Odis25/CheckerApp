﻿using CheckerApp.Shared.Models.Commands;
using FluentValidation;

namespace CheckerApp.Shared.Validators
{
    public class CreateContractCommandValidator : AbstractValidator<CreateContractCommandVm>
    {
        public CreateContractCommandValidator()
        {
            RuleFor(c => c.ContractNumber).NotEmpty().WithMessage("Не указан номер договора.");
            RuleFor(c => c.DomesticNumber).NotEmpty().WithMessage("Не указан внутренний номер договора.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Не указано название договора.");
        }
    }
}
