﻿using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.ContractEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Contracts.Commands.CreateContract
{
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateContractCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            var contract = new Contract
            {
                ContractNumber = request.ContractNumber,
                Name = request.Name,
                DomesticNumber = request.DomesticNumber
            };

            _context.Contracts.Add(contract);

            await _context.SaveChangesAsync(cancellationToken);

            return contract.Id;
        }
    }

}
