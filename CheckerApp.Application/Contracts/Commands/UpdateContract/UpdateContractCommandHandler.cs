using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Contracts.Commands.UpdateContract
{
    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateContractCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts.FindAsync(request.Id);

            contract.Name = request.Name;
            contract.ContractNumber = request.ContractNumber;
            contract.DomesticNumber = request.DomesticNumber;
            contract.ProjectNumber = request.ProjectNumber;

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
