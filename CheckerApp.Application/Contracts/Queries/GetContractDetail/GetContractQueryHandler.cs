using AutoMapper;
using AutoMapper.QueryableExtensions;
using CheckerApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Contracts.Queries.GetContractDetail
{
    public class GetContractQueryHandler : IRequestHandler<GetContractDetailQuery, ContractDetailDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetContractQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ContractDetailDto> Handle(GetContractDetailQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Contracts
                .Include(c => c.HardwareList)
                .ProjectTo<ContractDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            return res;
        }
    }

}
