using AutoMapper;
using CheckerApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class GetHardwateDetailQueryHandler : IRequestHandler<GetHardwareDetailQuery, HardwareVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetHardwateDetailQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HardwareVm> Handle(GetHardwareDetailQuery request, CancellationToken cancellationToken)
        {
            var result =  await _context.Hardwares
                .FirstOrDefaultAsync(h => h.Id == request.Id);

            return _mapper.Map<HardwareVm>(result);
        }
    }
}
