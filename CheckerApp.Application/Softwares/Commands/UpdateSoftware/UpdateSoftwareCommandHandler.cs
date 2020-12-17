using CheckerApp.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Softwares.Commands.UpdateSoftware
{
    public class UpdateSoftwareCommandHandler : IRequestHandler<UpdateSoftwareCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateSoftwareCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateSoftwareCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Softwares.FindAsync(request.Id);

            try
            {
                entity.Name = request.Name;
                entity.Version = request.Version;

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
