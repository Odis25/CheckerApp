using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.CheckEntities;
using CheckerApp.Domain.Entities.Documents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Checks.Commands.CreateContractCheck
{
    public class CreateCheckCommandHandler : IRequestHandler<CreateCheckCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateCheckCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCheckCommand request, CancellationToken cancellationToken)
        {
            var vm = request.ContractCheck;

            var hardwareChecks = vm.HardwareChecks.Select(hc => new HardwareCheck
            {
                HardwareId = hc.Hardware.Id,
                CheckParameters = hc.CheckParameters.Select(cp => 
                new CheckParameter
                {
                    Description = cp.Description,
                    Method = cp.Method,
                    Result = cp.Result,
                    Date = cp.Date,
                    Comment = cp.Comment
                }).ToList()
            }).ToList();

            var check = new ContractCheck
            {
                ContractId = vm.Contract.Id,
                HardwareChecks = hardwareChecks
            };

            _context.ContractChecks.Add(check);
            await _context.SaveChangesAsync(cancellationToken);

            return check.Id;
        }
    }
}
