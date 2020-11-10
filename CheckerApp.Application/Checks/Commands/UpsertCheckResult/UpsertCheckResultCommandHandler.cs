using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.CheckEntities;
using CheckerApp.Domain.Entities.Documents;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Checks.Commands.UpsertCheckResult
{
    public class UpsertCheckResultCommandHandler : IRequestHandler<UpsertCheckResultCommand, int>
    {
        private readonly IAppDbContext _context;

        public UpsertCheckResultCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpsertCheckResultCommand request, CancellationToken cancellationToken)
        {
            CheckResult entity;

            var checkResultDto = request.CheckResult;

            if (checkResultDto.Id.HasValue)
            {
                entity = await _context.CheckResults.FindAsync(checkResultDto.Id.Value);

                _context.Update(entity);
            }
            else
            {
                entity = new CheckResult { ContractId = checkResultDto.Contract.Id };

                _context.CheckResults.Add(entity);
            }

            entity.HardwareChecks.Clear();

            foreach (var checkDto in checkResultDto.HardwareChecks)
            {
                var check = new HardwareCheck { HardwareId = checkDto.Hardware.Id };

                foreach (var parameterDto in checkDto.CheckParameters)
                {
                    var parameter = new CheckParameter
                    {
                        Description = parameterDto.Description,
                        Method = parameterDto.Method,
                        Result = parameterDto.Result,
                        Date = parameterDto.Date,
                        Comment = parameterDto.Comment
                    };

                    check.CheckParameters.Add(parameter);
                }

                entity.HardwareChecks.Add(check);
            }

            var contract = await _context.Contracts.FindAsync(checkResultDto.Contract.Id);
            contract.HasProtocol = true;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }            

            return entity.Id;
        }
    }
}
