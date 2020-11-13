using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.CheckEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Checks.Commands.SaveCheckResult
{
    public class SaveCheckResultCommandHandler : IRequestHandler<SaveCheckResultCommand>
    {
        private readonly IAppDbContext _context;

        public SaveCheckResultCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SaveCheckResultCommand request, CancellationToken cancellationToken)
        {
            //todo: почистить код

            foreach (var checkDto in request.CheckResult.HardwareChecks)
            {
                var hardware = await _context.Hardwares.FindAsync(checkDto.Hardware.Id);

                hardware.CheckResult ??= new HardwareCheck();

                var parameters = hardware.CheckResult.CheckParameters;

                _context.CheckParameters.RemoveRange(parameters);

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

                    hardware.CheckResult.CheckParameters.Add(parameter);
                }
            }

            foreach (var checkDto in request.CheckResult.SoftwareChecks)
            {
                var software = await _context.Softwares.FindAsync(checkDto.Software.Id);

                software.CheckResult ??= new SoftwareCheck();

                var parameters = software.CheckResult.CheckParameters;

                _context.CheckParameters.RemoveRange(parameters);

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

                    software.CheckResult.CheckParameters.Add(parameter);
                }
            }

            var contract = await _context.Contracts.FindAsync(request.CheckResult.Contract.Id);
            contract.HasProtocol = true;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return Unit.Value;
        }
    }
}
