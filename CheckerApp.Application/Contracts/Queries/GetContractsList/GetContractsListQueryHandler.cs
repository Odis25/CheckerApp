using AutoMapper;
using AutoMapper.QueryableExtensions;
using CheckerApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Contracts.Queries.GetContractsList
{

    public class GetContractsListQueryHandler : IRequestHandler<GetContractsListQuery, ContractsListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetContractsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ContractsListVm> Handle(GetContractsListQuery request, CancellationToken cancellationToken)
        {
            var contracts = await _context.Contracts
                .Include(c=> c.HardwareList)
                .ProjectTo<ContractDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var vm = new ContractsListVm
            {
                Contracts = contracts
            };

            return vm;
        }
    }

}
