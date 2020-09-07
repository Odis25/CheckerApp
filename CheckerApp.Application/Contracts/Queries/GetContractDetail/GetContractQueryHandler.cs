using AutoMapper;
using AutoMapper.QueryableExtensions;
using CheckerApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Contracts.Queries.GetContractDetail
{
    public class GetContractQueryHandler : IRequestHandler<GetContractDetailQuery, ContractDetailVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetContractQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ContractDetailVm> Handle(GetContractDetailQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Contracts
                .Include(c => c.HardwareList)
                .ProjectTo<ContractDetailVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            return res;
        }
    }

}
