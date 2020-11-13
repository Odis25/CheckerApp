using CheckerApp.Application.Common.Exceptions;
using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.SoftwareEntities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Softwares.Commands.DeleteSoftware
{
    public class DeleteSoftwareCommandHandler : IRequestHandler<DeleteSoftwareCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteSoftwareCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteSoftwareCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Softwares.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Software), request.Id);
            }

            var parameters = entity.CheckResult?.CheckParameters;

            _context.CheckParameters.RemoveRange(parameters);

            _context.Softwares.Remove(entity);

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
