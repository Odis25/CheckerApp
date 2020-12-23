using CheckerApp.Application.Common.Exceptions;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.HardwareEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Hardwares.Commands.DeleteHardware
{
    public class DeleteHardwareCommandHandler : IRequestHandler<DeleteHardwareCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteHardwareCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteHardwareCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context.Hardwares.FindAsync(request.Id);
                var contract = await _context.Contracts.FindAsync(entity.ContractId);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Hardware), request.Id);
                }

                var parameters = entity.CheckResult?.CheckParameters;

                if (parameters != null)
                {
                    _context.CheckParameters.RemoveRange(parameters);
                }

                _context.Hardwares.Remove(entity);

                contract.HasProtocol = false;

                _context.Update(contract);

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
