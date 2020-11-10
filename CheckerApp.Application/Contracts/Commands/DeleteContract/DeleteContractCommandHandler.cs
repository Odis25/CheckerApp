using CheckerApp.Application.Common.Exceptions;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.ContractEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Contracts.Commands.DeleteContract
{
    public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteContractCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contracts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contract), entity);
            }

            foreach (var hardware in entity.HardwareList)
            {
                _context.Hardwares.Remove(hardware);
            }

            _context.Contracts.Remove(entity);

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
