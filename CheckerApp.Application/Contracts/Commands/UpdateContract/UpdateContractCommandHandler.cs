using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var contract = await _context.Contracts.Include(c => c.HardwareList).FirstOrDefaultAsync();
            
            contract.Name = request.Name;
            contract.ContractNumber = request.ContractNumber;
            contract.DomesticNumber = request.DomesticNumber;
            
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
